class UserLogged {
    roles = [];
    constructor(){

    }
    isRole(role){        
        return this.roles.some(x => x === role)
    }
}