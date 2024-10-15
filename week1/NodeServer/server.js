import {createServer} from 'node:http';
console.log('Fixing to set up the server');
const server = createServer((req,res)=>{
    res.writeHead(200, {'Content-Type' : 'application/json'});
    const response = {
        name : 'Kaung',
        email: 'Kaung@lwin.com'
    };
    const json = JSON.stringify(response);
    res.end(json);
});
console.log('About ready start');
server.listen(1338, '127.0.0.1', ()=>{
    console.log('Running your api...');
})


