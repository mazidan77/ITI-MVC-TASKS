

var ssn = document.getElementById("ESSN");
var projectArea = document.getElementById("projectArea");

var projectinput = document.getElementById("Pnum");

var hourarea = document.getElementById("hourarea");

ssn.addEventListener("change", async() => {

    var projectsResult = await fetch(`http://localhost:5139/workfor/projects/${ssn.value}`);
    var projectlist = await projectsResult.text();

    projectArea.innerHTML = projectlist;
    projectinput = document.getElementById("Pnum");
  

    projectinput.addEventListener("change", async () => {
        console.log(projectinput)
        var hourResult = await fetch(`http://localhost:5139/workfor/Hours/${ssn.value}?num=${projectinput.value}`)
        var hour = await hourResult.text()

        hourarea.innerHTML = hour;
    })
});