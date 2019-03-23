var primaryColor = "#1373c2";
var secondaryColor = "#474d51";
function mapColor(){
    document.getElementById("mapBtnI").style.backgroundColor = primaryColor;
    document.getElementById("listBtnI").style.backgroundColor = secondaryColor;
}

function mlSwitch(target, sw){
    document.getElementById(target).style.display = "none";
    document.getElementById(sw).style.display = "block";
    if(sw == "map"){
        mapColor();
    }if (sw=="list"){
        document.getElementById("listBtnII").style.backgroundColor = primaryColor;
        document.getElementById("mapBtnII").style.backgroundColor = secondaryColor;  
    }
}