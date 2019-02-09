module.exports = {
    Ver:Ver,
    Editar:Editar,
    Nuevo:Nuevo,
    PostUser:PostUser
}

function Ver (req, res){
    res.locals.id = req.params.id;
    res.render('Users/Ver');
}


function Editar (req, res){
    res.locals.id = req.params.id;
    res.render('Users/Editar');
}
function Nuevo(req,res){
    res.render('users/Nuevo');
}

function PostUser(req,res){
    console.log(req.body.nameUser);   
}