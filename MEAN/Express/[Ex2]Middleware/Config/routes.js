
var cats = require('../Controllers/homeController');
module.exports= (app)=> {
    app.get('/api/cats', cats.BuildCats),
    app.get('/api/cats/:name', cats.GetCats)
}

