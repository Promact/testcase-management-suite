var fs = require('fs');
var resources = [
    'node_modules/core-js/client/shim.min.js',
    'node_modules/zone.js/dist/zone.min.js',
    'src/styles.css',
    'node_modules/bootstrap/dist/css/bootstrap.css',
    'node_modules/@@angular/material/prebuilt-themes/indigo-pink.css'
];
resources.map(function (f) {
    var path = f.split('/');
    var t = 'aot/' + path[path.length - 1];
    fs.createReadStream(f).pipe(fs.createWriteStream(t));
});