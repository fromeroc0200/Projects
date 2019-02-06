module.exports= {
    GetUser:GetUser
}

function GetUser(req, res){
    
    //--Colocamos una res.locals
    res.locals.userName = req.params.userName;
    console.log(res.locals.userName);
    res.send('hola ' +res.locals.userName);
}