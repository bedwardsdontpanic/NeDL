export default class Style  {

    public static getCss(w:number): string {

      let m = Math.floor((w - 515) / 2);
      console.log(`margin = ${m}`);

        let css: string = `
            <style>

                .pollsModal {
                    display: none; 
                    position: fixed;
                    paddin: 0; 
                    left: 0;
                    top: 0;
                    width: 100%; 
                    height: 100%; 
                    overflow: auto; 
                    background-color: rgb(0,0,0); 
                    background-color: rgba(0,0,0,0.75); 
                    z-index: 999;
                  }
              
                  .pollsModalContent {
                    position: fixed;
                    top: -200px;
                    left: ${m}px;
                    opacity: 1;
                    z-index: 1000;
                    width: 515px;
                    margin: 0 !important;
                  }
                  
              
                  .pollsCloseButton {
                    color: #aaaaaa;
                    float: right;
                    font-size: 28px;
                    font-weight: bold;
                  }
                  
                  .pollsCloseButton:hover,
                  .pollsCloseButton:focus {
                    color: #000;
                    text-decoration: none;
                    cursor: pointer;
                  }

            </style>
        `;

        return css;

    }
}