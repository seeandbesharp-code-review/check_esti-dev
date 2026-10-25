const checkPassword = async () => {
    try {
        const pass = document.querySelector("#password").value
        if (pass == '') {
            throw ("empty password")
        }
        const response = await fetch('api/Passwords', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(pass)
        })
        if (!response.ok) {
            throw ("try again")
        }
        const score = await response.json()
        const progress = document.querySelector("#passwordProgress")
        progress.value = score;
        if (score < 3) {
            throw ("not a strong password")
        }
    }
    catch (e) {
        alert(e)
    }

}
const signIn =async() => {
    try {
        await checkPassword()
        const progress = document.querySelector("#passwordProgress")
        if (progress.value < 3) {
            return
        }
        const postData = {
            email: document.querySelector("#email").value,
            firstName: document.querySelector("#firstName").value,
            lastName: document.querySelector("#lastName").value,
            password: document.querySelector("#password").value,
        }

        const response = await fetch('api/Users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(postData)
        })

        if (response.ok)
            alert("user successfully added");
        else
            throw ("try again");
    }
    catch (e) {
        alert(e);
    }
  
}

const LogIn = async () => {

    try {
        const postData = {
            email: document.querySelector("#logemail").value,
            password: document.querySelector("#logpassword").value,
        }

        const response = await fetch('api/Users/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(postData)
        })

        if (!response.ok)
            throw ("try again enter the details");

        else {
            const data = (await (response.json()));
            sessionStorage.setItem("currentUser", await (JSON.stringify(data)));
            signlog = document.querySelector(".signlog");
            signlog.style.display = "none";
            succses = document.querySelector(".succses");
            succses.textContent = data.firstName + " " + succses.textContent;
            succses.style.display = "block";
            succses.style.backgroundColor = "gray";
            succses.style.width = "200px";
            succses.style.height = "200px";
            const updateLink = document.querySelector("#updateLink");
            updateLink.style.display = "block";
         }
    }
    catch(e) {
        alert(e);
    }
   
}

const newUser = () => {
    const newUser = document.querySelector("#newUser");
    newUser.style.display = "none";
    const left = document.querySelector(".left");
    left.style.display = "block";
}

