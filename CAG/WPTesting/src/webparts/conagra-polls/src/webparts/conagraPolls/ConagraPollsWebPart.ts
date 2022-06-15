import { Version } from '@microsoft/sp-core-library';
import {
  IPropertyPaneConfiguration,
  PropertyPaneTextField,
  PropertyPaneCheckbox,
  PropertyPaneToggle
} from '@microsoft/sp-property-pane';
import { BaseClientSideWebPart } from '@microsoft/sp-webpart-base';
import { escape } from '@microsoft/sp-lodash-subset';
import { Web, List, ItemAddResult } from "sp-pnp-js/lib/pnp";

import {
  SPHttpClient,
  SPHttpClientResponse,
  ISPHttpClientOptions   
} from '@microsoft/sp-http';

import styles from './ConagraPollsWebPart.module.scss';
import * as strings from 'ConagraPollsWebPartStrings';

import MockHttpClient from './MockHttpClient';
import Utils from './utils';
import inlineStyle from './style';

import { SPComponentLoader } from '@microsoft/sp-loader';

import * as $ from 'jquery';
import * as bootstrap from 'bootstrap';
import axios from 'axios';
import * as moment from 'moment';

import { WebPartContext } from "@microsoft/sp-webpart-base";


export interface IConagraPollsWebPartProps {
  context: WebPartContext;
  description: string;
  surveyStatus: boolean;
  useMock: boolean;
  impersonateUser: string;
  surveyDate: string;
  currentUser: string;
  pulseHost: string;
  pulseHRAT: string;
  logic_app_base_url: string;
  logic_app_resource_ID: string;
  logic_app_sas: string;
  logic_app_base_activity_url: string;
  logic_app_resource_activity_ID: string;
  logic_app_activity_sas: string;
  activityAPI: string;
  responseAPI: string;
  ResponseObjects: ResponseObject[];
  surveyDelay: number;
}

export interface IResponseObject {
  campaign_id: number;
	question_id: number;
	zid: string;
	response_value : string;
}

export class ResponseObject implements IResponseObject {
  public campaign_id: number;
  public question_id: number;
  public zid: string;
  public  response_value: string;
}

export interface IResponse {
  count: number;
  next: any;
  previous: any;
  results: IResult[];
}
export interface IResult {
  queue_id: number;
  zid: string;
  responded: boolean;
  Campaign: ICampaign;
  strongly_disagree: string;
  neutral: string;
  strongly_agree: string;
  snooze: string;
  submit: string;
  complete: string;
  wait: string;
  try_again: string;
  ok: string;
  thank_you: string;
}

export interface ICampaign {
  campaign_id: number;
  active_from: Date;
  active_to: Date;
  Questions: IQuestion[];
}

export interface IQuestion {
  question_id: number;
  question_text: string;
}

export default class ConagraPollsWebPart extends BaseClientSideWebPart <IConagraPollsWebPartProps> {

  private readonly MOBILE_BREAKPOINT: number = 768;

  protected onInit(): Promise<void> {
    SPComponentLoader.loadCss('https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css');
    SPComponentLoader.loadCss('https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css');

    SPComponentLoader.loadScript('https://cdnjs.cloudflare.com/ajax/libs/jquery/1.9.1/jquery.min.js', { globalExportsName: 'jQuery' }).then((jQuery: any): void => {
      SPComponentLoader.loadScript('https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/js/bootstrap.min.js',  { globalExportsName: 'jQuery' }).then((): void => {
      });
    });

    return super.onInit();
  }

  private _getCurrentUser(): string {
    if (this.properties.impersonateUser != null) {
      if (this.properties.impersonateUser.trim().length > 0) {
        return this.properties.impersonateUser.trim();
      } else {
        return Utils.formatUserName(this.context.pageContext.user.loginName);
      }
    } else {
      return Utils.formatUserName(this.context.pageContext.user.loginName);
    }
  }

  private _getCurrentDate(): string {
      let date:string = moment(new Date()).format('YYYY-MM-DD');
      return date;
    }

  private async _getPollsData(): Promise<IResponse> {
    let cache_buster = Math.random().toString(36).substring(2);
    let dateString = this._getCurrentDate();
    let _url = this.properties.pulseHost + '/api/v1/queue/active/' + dateString + '?zid=' + this.properties.currentUser + '&cache_buster=' + cache_buster;
    var _headers = {
      'Content-Type': "text/plain",
      'Authorization': this.properties.pulseHRAT,
      'X-Requested-With': "HREngagement",
    };

    const requestOptions: ISPHttpClientOptions = {
      headers: new Headers(_headers),
      credentials: 'same-origin',
      method: 'GET',
      redirect: 'follow'
    };

    return this.context.spHttpClient.get(_url, SPHttpClient.configurations.v1, requestOptions)
      .then((response: SPHttpClientResponse) => {
        return response.json();
    });
  }

  private async _renderPollsAsync() {
    if (this.properties.useMock == false) {      
      const response = await this._getPollsData();
      this._renderPolls(response);
    } else {
      const response = await this._getMockPollsData();
      this._renderPolls(response);
    }
  }

  private async _renderPolls(response: IResponse) {
    if (response.results != null && response.results.length > 0) {
      let result:IResult = response.results[0];
      if (response.results[0].Campaign.Questions.length > 0) {
        let html: string =  "";
        for (let i = 0; i < result.Campaign.Questions.length; i++) {

          html += `
              <div id="div${ i }">
							<table style="border:0px; width:100%">
							  <tr><td colspan="10"><h6 style="font-weight:bold; font-size:16px;">${ result.Campaign.Questions[i].question_text }</h6></td></tr>
								<tr>
								  <td colspan="2" style="width:20%"><label id="label1_${ result.Campaign.Questions[i].question_id }" class="${ styles.label}" style="background-color: #FF0000;"><input type="checkbox" class="${ styles.input }" value="${result.Campaign.campaign_id }|${result.Campaign.Questions[i].question_id}|1" autocomplete="off" />1</label></td>
								  <td colspan="2" style="width:20%"><label id="label2_${ result.Campaign.Questions[i].question_id }" class="${ styles.label}" style="background-color: #FF9900;"><input type="checkbox" class="${ styles.input }" value="${result.Campaign.campaign_id }|${result.Campaign.Questions[i].question_id}|2" autocomplete="off" />2</label></td>
								  <td colspan="2" style="width:20%"><label id="label3_${ result.Campaign.Questions[i].question_id }" class="${ styles.label}" style="background-color: #FFFF00;"><input type="checkbox" class="${ styles.input }"  value="${result.Campaign.campaign_id }|${result.Campaign.Questions[i].question_id}|3" autocomplete="off" />3</label></td>
								  <td colspan="2" style="width:20%"><label id="label4_${ result.Campaign.Questions[i].question_id }" class="${ styles.label}" style="background-color: #99FF00;"><input type="checkbox" class="${ styles.input }"  value="${result.Campaign.campaign_id }|${result.Campaign.Questions[i].question_id}|4" autocomplete="off" />4</label></td>
								  <td colspan="2" style="width:20%"><label id="label5_${ result.Campaign.Questions[i].question_id }" class="${ styles.label}" style="background-color: #39C434;"><input type="checkbox" class="${ styles.input }" value="${result.Campaign.campaign_id }|${result.Campaign.Questions[i].question_id}|5" autocomplete="off" />5</label></td>
								</tr>
								<tr>
								  <td colspan="3" style="padding-top: 5px; padding-left: 2px; text-align: left;"><span style="font-size:12px"btn class="help-block">${result.strongly_disagree}</span></td>
								  <td></td>
								  <td colspan="2" style="padding-top: 5px; text-align: center;"><span style="font-size:12px"btn class="help-block">${result.neutral}</span></td>
								  <td></td>
								  <td colspan="3" style="padding-top: 5px; padding-right: 2px; text-align: right;"><span style="font-size:12px"btn class="help-block">${result.strongly_agree}</span></td>
								</tr>
								<tr><td colspan="10"><hr style="margin-top: 0px; margin-bottom: 0px;"></td></tr>
							</table>
						</div>
          `;
        }

        this._renderPopups(result);
        // survey delay to avoid popping up too quickly
        let millisecs = 8000;
        if (this.properties.surveyDelay > 0 && this.properties.surveyDelay <= 10) {
          millisecs = this.properties.surveyDelay * 1000;
        }
        
        await Utils.delay(1000);
        this._openQuestionare();

        $('#questionareModalQuestions').html(html);
    
        this._addEventListeners(result);
        this._postData(this.properties.activityAPI, [{zid: this.properties.currentUser, action: 'active_found_displayed',campaign_id: Number(result.Campaign.campaign_id)}]);

      }
    } else {
        this._postData(this.properties.activityAPI, [{zid: this.properties.currentUser, action: 'checkactive_none',campaign_id: -1}]);
      }
  }
  
  private _getMockPollsData(): Promise<IResponse> {
    return MockHttpClient.getQuestionList()
    .then((data: IResponse) => {
      return data;
    }) as Promise<IResponse>;    
  }

  public async render(): Promise<void> {

    if(this.properties.useMock == null) {
      this.properties.useMock = true;
    }

    if(!this.properties.surveyDelay) {
      this.properties.surveyDelay = 8;
    }

    let w:number = parseInt(window.innerWidth.toString().replace('px',''));

    // Polls are not supported in mobile devices
    if (w > this.MOBILE_BREAKPOINT) {
      if (this.properties.surveyStatus == true) {
        await this._initProperties();
  
        if (this.properties.pulseHRAT || this.properties.useMock) { 
          this.properties.ResponseObjects = [];
          
          let html: string = inlineStyle.getCss(w);
          html += `<div class=" ${styles.invisible} " id="surveyContainer" />`;
          this.domElement.innerHTML = html;
          await this._renderPollsAsync();
        }
      }
    }
  }

  private _renderPopups(result:IResult): void {
    
    let html: string = `
    <div class="pollsModal"></div>

    <div class="pollsModalContent" id="questionareModal">

      <div class="modal-content" style="width: 515px;">
        <div class="modal-header" style="margin-top: -90px"> 
          <img style="width: 515px; height: 100px; margin-top: 75px; margin-left: -15px;margin-bottom: -140px; opacity: 0.3;" src="${ this.context.pageContext.web.absoluteUrl }/_catalogs/masterpage/ConAgra/images/global/Woodgrain%20Backdrop%20-%20November%202018.jpg" />
          <img style="width: 125px; margin-top:50px" src="${ this.context.pageContext.web.absoluteUrl }/_catalogs/masterpage/ConAgra/images/global/Conagra%20Experience%20Logo.png" />
          <img style="width: 250px; margin-left: 35px; margin-top: 55px;" src="${ this.context.pageContext.web.absoluteUrl }/_catalogs/masterpage/ConAgra/images/global/Capturing%20the%20Pulse%20(002).JPG" />
        </div>
        <div class="modal-body" style="margin-left: 15px;">
          <div class="container-fluid" id="questionareModalQuestions"></div>
        </div>
        <div class="modal-footer">
          <button id="snoozeButton" type="button" class="btn btn-default" style="background-color:#adadad">${result.snooze}</button>
          <button id="submitButton" type="button" class="btn btn-primary">${result.submit}</button>
        </div>
      </div>

    </div>

    <div id="successModal" class="pollsModalContent">
      <div class="modal-dialog modal-confirm">
        <div class="modal-content">
          <div class="modal-header">
            <div class="icon-box">
              <i class="fa fa-check-square-o fa-lg" style="color:green" aria-hidden="true"></i>
            </div>				
            <h4 class="modal-title" style="color:green">${result.complete}</h4>	
          </div>
          <div class="modal-body">
            <p class="text-center" id="successUserName">${result.thank_you}</p>
          </div>
          <div class="modal-footer">
            <button id="closeSuccessModal" class="btn btn-success btn-block">OK</button>
          </div>
        </div>
      </div>
    </div>

    <div id="errorModal" class="pollsModalContent" data-backdrop="static">
      <div class="modal-dialog modal-confirm">
        <div class="modal-content">
          <div class="modal-header">
            <div class="icon-box">
              <i class="fa fa-exclamation-circle fa-lg" style="color:red" aria-hidden="true"></i>
            </div>				
            <h4 class="modal-title" style="color:red">${result.wait}</h4>	
          </div>
          <div class="modal-body">
            <p class="text-center">${result.try_again}</p>
          </div>
          <div class="modal-footer">
            <button id="reopenQuestionareButton" class="btn btn-danger btn-block">${result.ok}</button>
          </div>
        </div>
      </div>
    </div>

    `;

    $('#surveyContainer').html(html);
    
  }

  public _addEventListeners(result: IResult): void { 

    $('#snoozeButton').click(() => {
      this._snooze(result);
    });

    $('#submitButton').click(() => {
      this._submit(result);
    });

    $('#closeSuccessModal').click(() => {
      this._modal('hide', 'successModal');
    });

    $('#reopenQuestionareButton').click(() => {
      this._postData(this.properties.activityAPI,[{zid: this.properties.currentUser, action: 'warning_not_filled_out', campaign_id: Number(result.Campaign.campaign_id)}]);
      this._openQuestionare(); 
    });
    
    let inputs= document.getElementsByClassName(styles.input);
    for(let i=0 ; i < inputs.length; i++){
      inputs[i].addEventListener('click', (event) => {
        this._toggle(event, result);
      });
    }
  }

  private _snooze(result: IResult): void{    
    this._modal('hide', 'questionareModal');
    
    this._postData(this.properties.activityAPI, 
                    [{zid: this.properties.currentUser,
                      action: 'snooze_button_clicked',
                      campaign_id: Number(result.Campaign.campaign_id)
                    }]
                  );
    

  }

  private _submit(result: IResult): void{
    if (this.properties.ResponseObjects.length > 0) {
      var filteredList = this.properties.ResponseObjects.filter((i) => i.campaign_id == result.Campaign.campaign_id);
      if (filteredList.length > 0) {
        if (filteredList.length == result.Campaign.Questions.length) {
          this._postData(this.properties.responseAPI, filteredList);
          this._patchData(this.properties.pulseHost + '/api/v1/queue/' + result.queue_id.toString(), {responded: true});
          this._postData(this.properties.activityAPI, 
            [{zid: this.properties.currentUser,
              action: 'response_submitted_successfully',
              campaign_id: Number(result.Campaign.campaign_id)
            }]
          );
          this._modal('show','successModal');
          setTimeout(function() { 
            this._modal('hide','successModal');
          }, 2000);
        } else {
          this._modal('show','errorModal');
        }
      } else {
        this._modal('show','errorModal');
      }
    } else {
      this._modal('show','errorModal');
    }
  }

  private _toggle(event, result: IResult): void {
    let values = event.target.value.toString().split('|');
    if (values.length == 3) {
      let _campaign_id = values[0];
      let _question_id = values[1];
      let _response_value = values[2];
      this._updateResponseObjects(_campaign_id, _question_id, _response_value);  
      for (let j = 1; j < 6; j++) {
        let lbl = '#label' + j + '_' + _question_id;
        let label: Element = this.domElement.querySelector(lbl);                                                          
        if (label != null) {
          if (j == _response_value) {
            label.className = styles.labelActive;
          } else {
            label.className = styles.label;
          }
        } else {
          console.log("not found: " + lbl);
        }
      }
    }
  }

  private _openQuestionare(): void {
    const surveyContainer: Element = this.domElement.querySelector('#surveyContainer');
    if (surveyContainer != null) {
      surveyContainer.className = styles.conagraPolls;
      this._modal('show','questionareModal');
    }
  }

  private _postData(url: string, data_object: object){	
    var _headers = {'Accept': "application/json",
                    'Content-Type': "application/json;charset=UTF-8",
                    'X-Requested-With': 'XMLHttpRequest'};
    if (this.properties.useMock == false) {
      axios({
        method: 'POST',
        url: url,
        headers: _headers,
        data: data_object
      });
    }
  }

  private _patchData(url: string, data_object: object){	
    var _headers = {
      'Accept': "application/json",
      'Content-Type': "application/json;charset=UTF-8",
      'Authorization': this.properties.pulseHRAT,
      'X-Requested-With': 'XMLHttpRequest'
    };
    if (this.properties.useMock == false) {
      axios({
        method: 'PATCH',
        url: url,
        headers: _headers,
        data: data_object
      });
    }
  }

  private _updateResponseObjects(campaign_id: number, question_id: number, response_value: string): void {
    for (let i = 0; i < this.properties.ResponseObjects.length; i++) {
      if (this.properties.ResponseObjects[i].campaign_id == campaign_id && this.properties.ResponseObjects[i].question_id == question_id) {
        this.properties.ResponseObjects.splice(i--, 1);
      }
    }
    this.properties.ResponseObjects.push({zid: this.properties.currentUser, campaign_id: Number(campaign_id), question_id: Number(question_id), response_value: response_value});
  }

  private _modal(action:string, modalName:string) {
    if (action == 'show') {
      $('.pollsModal').css('display', 'block');
      $('.pollsModalContent').css('top', '-200px');
      $('.pollsModalContent').css('opacity', '0');
      $(`#${modalName}`).animate({opacity: '1'}, 200);
      $(`#${modalName}`).animate({top: '50px'}, 300);
      $('.pollsModalContent').css('z-index', '1000');
      $(`#${modalName}`).css('z-index', '1001');
    } else if (action == 'hide') {
      $(`#${modalName}`).animate({opacity: '0'}, 200);
      $(`.${modalName}`).animate({top: '-200px'}, 300);
      $('.pollsModal').css('display', 'none');
    }
  }

  protected get dataVersion(): Version {
    return Version.parse('1.0');
  }

  protected get disableReactivePropertyChanges(): boolean {
    return true;
  }

  protected getPropertyPaneConfiguration(): IPropertyPaneConfiguration {
    return {
      pages: [
        {
          header: {
            description: strings.PropertyPaneDescription
          },
          groups: [
            {
              groupName: strings.BasicGroupName,
              groupFields: [
                PropertyPaneTextField('description', {
                  label: strings.DescriptionFieldLabel
                }),
                PropertyPaneToggle('surveyStatus', {
                  label: 'Status'
                }),
                PropertyPaneCheckbox('useMock', {
                  checked: true,
                  text: "Use Mock Data"
                }),
                PropertyPaneTextField('surveyDelay', {
                  label: "Pop-up delay (1 to 10 seconds)"
                }),
                PropertyPaneTextField('impersonateUser', {
                  label: "Impersonate User"
                }),
                PropertyPaneTextField('surveyDate', {
                  label: "Survey Date"
                })
              ]
            }
          ]
        }
      ]
    };
  }

  private async _initProperties() {
    let variablesOk: boolean = true;
    this.properties.currentUser = this._getCurrentUser();
     
    if (this.properties.useMock == false) {
      let web = new Web(this.context.pageContext.web.absoluteUrl);
      const json: any = await web.getFileByServerRelativeUrl(this.context.pageContext.web.serverRelativeUrl + "/_catalogs/masterpage/O365/js/pulseHR2.json").getJSON();

      if (json.pulseHost) {
        this.properties.pulseHost = json.pulseHost;
      } else {
        variablesOk = false;
      }
      if (json.pulseHRAT) {
        this.properties.pulseHRAT = json.pulseHRAT;
      } else {
        variablesOk = false;
      }
      if (json.logic_app_base_url) {
        this.properties.logic_app_base_url = json.logic_app_base_url;
      } else {
        variablesOk = false;
      }
      if (json.logic_app_resource_ID) {
        this.properties.logic_app_resource_ID = json.logic_app_resource_ID;
      } else {
        variablesOk = false;
      }
      if (json.logic_app_sas) {
        this.properties.logic_app_sas = json.logic_app_sas;
      } else {
        variablesOk = false;
      }
      if (json.logic_app_base_activity_url) {
        this.properties.logic_app_base_activity_url = json.logic_app_base_activity_url;
      } else {
        variablesOk = false;
      }
      if (json.logic_app_resource_activity_ID) {
        this.properties.logic_app_resource_activity_ID = json.logic_app_resource_activity_ID;
      } else {
        variablesOk = false;
      }
      if (json.logic_app_activity_sas) {
        this.properties.logic_app_activity_sas = json.logic_app_activity_sas;
      } else {
        variablesOk = false;
      }
    }
    
    if (variablesOk) {
      this.properties.activityAPI = 'https://' + this.properties.logic_app_base_activity_url + '/workflows/' + this.properties.logic_app_resource_activity_ID + '/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=' + this.properties.logic_app_activity_sas;
      this.properties.responseAPI = 'https://' + this.properties.logic_app_base_url + '/workflows/' + this.properties.logic_app_resource_ID + '/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=' + this.properties.logic_app_sas;
    } else {
      console.log("Variables missing. Revise json config file.");
    }
    
  }
}
