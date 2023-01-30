console.log("jjjjj")

var ssn = document.getElementById("ESSN");
var projectArea = document.getElementById("projectArea");

ssn.addEventListener("change", async() => {

    var projectsResult = await fetch(`http://localhost:5139/workfor/projects/${ssn.value}`);
    var projectlist = await projectsResult.text();
    console.log(projectlist)
    projectArea.innerHTML = projectlist;
});