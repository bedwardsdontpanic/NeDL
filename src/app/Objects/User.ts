export interface User {
    username: string;
    email: string;
}

function User(username, email) {
    this.username = username;
    this.email = email;
}