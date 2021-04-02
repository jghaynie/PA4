var posts = [];

function populateTable(){
    getPosts();
}

function handleOnLoad(){
    populateTable();
}

function getPosts(){
    console.log("getting posts");
    const postURL = "https://localhost:5001/api/posts";
    
    fetch(postURL).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html="<div class=\"container\"><table class=\"table table-dark table-striped\">"
        html+= "<thead><tr><th scope=\"col\">#</th><th scope=\"col\">Post</th><th scope=\"col\">Timestamp</th><th scope=\"col\">Edit</th><th scope=\"col\">Delete</th></tr></thead><tbody>";
        json.forEach((posts)=>{
            var date = new Date(Date.parse(posts.timestamp));
            var dateFormat = date.getHours() + ":" + date.getMinutes() + " - " + date.getMonth() + "/" + (date.getUTCDate() + 1) + "/" + (date.getFullYear());
            html+= "<tr><th scope=\"row\">" + posts.id + "</th><td>" + posts.post + "</td><td>" + dateFormat + "</td><td>" + editModal(posts) + "</td><td>" + "<button type=\"button\" class=\"btn btn-danger\" onclick=\"deleteButton("+posts.id+")\" id=\"deleteButton'{id}'\">Delete</button>" + "</td></tr>"
        })
        html+="</tbody></table></div>"
        document.getElementById("postTable").innerHTML = html;
        console.log(json);
    }).catch(function(error){
        console.log(error);
    });
}

function handleAddPost(){
    const postApiUrl = "https://localhost:5001/api/posts";
    const inputPost = document.getElementById("post").value;
    let newPost = {
        Post: inputPost
    };
    fetch(postApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        }, 
        body: JSON.stringify(newPost)
    }).then(function(response){
        console.log(response);
        document.getElementById("post").value = "";
        getPosts();
    });
}

function editModal(posts) {
    console.log("test please work");
    return "<button type=\"button\" class=\"btn btn-primary\" data-toggle=\"modal\" data-target=\"#exampleModalCenter\">Edit</button><div class=\"modal fade\" id=\"exampleModalCenter\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"exampleModalCenterTitle\" aria-hidden=\"true\"><div class=\"modal-dialog modal-dialog-centered\" role=\"document\"><div class=\"modal-content\"><div class=\"modal-header\"><h5 class=\"modal-title\" id=\"modal-title\">Edit Post</h5><button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button></div><div class=\"modal-body\"><input type=\"text\" class=\"form-control\" placeholder=\"Enter updated post\" aria-label=\"updated post\" aria-describedby=\"basic-addon2\" id=\"alterPostText\"></div><div class=\"modal-footer\"><button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">Cancel</button><button type=\"button\" class=\"btn btn-primary\" onclick=\"updatePost("+posts.id+")\" id=\"updateButton\" data-dismiss=\"modal\">Submit</button></div></div></div></div>"
}

function deleteButton(id) {
    const url = "https://localhost:5001/api/posts";
    fetch(`${uri}/${id}`, {
      method: 'DELETE'
    })
    .then(() => getPosts())
    .catch(error => console.error('Unable to delete item.', error));
  }

function updatePost(postId){
    const postURL = "https://localhost:5001/api/posts/" + postId;
    let updatedPost = {
        Id: postId,
        Post: document.getElementById('alterPostText').value,
    };

    fetch(postURL, {
        method: 'PUT',
        headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
        },
        body: JSON.stringify(updatedPost)
    }).then(() => getPosts()).catch(error => console.error('Unable to update item.', error));
}