window.searchObject = {
    name: null
}
$(document).ready(function () {
    showProjects();
});

function showProjects() {
    $.ajax({
        url: "api/projects",
        method: "get",
        success: function (projects) {
            let html = "";
            if (projects.length > 0) {
                for (let project of projects) {
                    html += `<td>${project.Id}</td>
            <td>${project.Name}</td>
            <td>${project.Code}</td>`;
                }
            } else {
                html += "<h3>No projects</h3>";
            }
            $("#projectData").html(html);
        },
        error: function (err) {
            console.log(err);
        }
    });
}



function printProjects(projects) {
    let html = "";
    if (projects.length > 0) {
        for (let project of projects) {
            html += printSingleProject(project);
        }
    } else {
        html += "<h3>No projects</h3>";
    }
    $("#projectData").html(html);
}

function printSingleProject(project) {
    return `
            <td>${project.Id}</td>
            <td>${project.Name}</td>
            <td>${project.Code}</td>
    `;
}
