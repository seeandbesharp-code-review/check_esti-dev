const email = document.querySelector("#email");
const firstName = document.querySelector("#firstName");
const lastName = document.querySelector("#lastName");
const password = document.querySelector("#password");
const data = JSON.parse(sessionStorage.getItem("currentUser"));
email.value = data.email;
firstName.value = data.firstName;
lastName.value = data.lastName;
password.value = data.password;

const upDate = async() => {
    try {
        const putData = {
            email: document.querySelector("#email").value,
            firstName: document.querySelector("#firstName").value,
            lastName: document.querySelector("#lastName").value,
            password: document.querySelector("#password").value,
            id : data.id,
        }
        const response = await fetch('api/Users/' +data.id, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(putData)
        })

        if(response.ok)
            alert("user successfully update");
        else
            throw("try again");
    }
    catch(e) {
        alert(e);
    }

 }
