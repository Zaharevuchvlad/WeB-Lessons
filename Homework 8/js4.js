class Css{
    constructor(Name,style=[]){
    this.Name=Name;
    this.style=style
    }
   
}
Css.Name="Color style"
console.log(`Name: ${Css.Name}`)
let style=["arial","black","yellow"]
 // add property
 Css.metod = style;
 console.log(`metod: ${Css.metod} `);
 
 // remove property
 delete Css.metod;
 console.log(`metod del: ${Css.metod} `);