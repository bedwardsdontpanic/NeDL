import { IResponse, IResult, ICampaign, IQuestion } from './ConagraPollsWebPart';

export default class MockHttpClient  {

    private static _results: IResponse = {count:1,
                                          next:null,
                                          previous:null,
                                          results:[{queue_id:148016,
                                                    zid:"ZJC3134",
                                                    responded:false,
                                                    Campaign:{"campaign_id":75,
                                                    active_from:new Date("2020-05-19"),
                                                    active_to:new Date("2020-05-19"),
                                                    Questions:[{question_id:16,
                                                                question_text:"I like Mock Data"
                                                              },
                                                              {question_id:17,
                                                                question_text:"I like SharePoint"
                                                              },
                                                              {question_id:18,
                                                                question_text:"This Survey is cool"
                                                              }]
                                                    },
                                                    "strongly_disagree": "Strongly Disagree",
                                                    "neutral": "Neutral",
                                                    "strongly_agree": "Strongly Agree",
                                                    "snooze": "Snooze",
                                                    "submit": "Submit",
                                                    "complete": "Complete!",
                                                    "wait": "Wait!",
                                                    "try_again": "You forgot to answer one or more questions! Please press OK to try again.",
                                                    "ok": "OK",
                                                    "thank_you": "Thank you for taking the time to answer."
                                                    }
                                        ]};

    private static _emprtySet: IResponse = {"count":0,"next":null,"previous":null,"results":[]};

    public static getQuestionList(): Promise<IResponse> {
        return new Promise<IResponse>((resolve) => {
            resolve(MockHttpClient._results);
        });
    }

    public static getEmptySet(): Promise<IResponse> {
        return new Promise<IResponse>((resolve) => {
            resolve(MockHttpClient._emprtySet);
        });
    }
}