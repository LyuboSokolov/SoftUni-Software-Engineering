function solve(obj) {

    let validMethod = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let regex = new RegExp('[A-Za-z.0-9]*');
    let validVersion = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    let regexMessage = new RegExp('\w*\d*[^<>\\&\'"]');

    if (!obj.hasOwnProperty('method')) {

        throw new Error('Invalid request header: Invalid Method');

    } else if (!obj.hasOwnProperty('uri')) {

        throw new Error('Invalid request header: Invalid URI');

    } else if (!obj.hasOwnProperty('version')) {

        throw new Error('Invalid request header: Invalid Version');

    } else if (!obj.hasOwnProperty('message')) {

        throw new Error('Invalid request header: Invalid Message')

    } else if (!validMethod.includes(obj.method)) {

        throw new Error('Invalid request header: Invalid Method');

    } else if (!(obj.uri.match(regex)[0] === obj.uri) || (obj.uri === null || obj.uri.match(/^ *$/) !== null)) {

        throw new Error('Invalid request header: Invalid URI');

    } else if (!validVersion.includes(obj.version)) {

        throw new Error('Invalid request header: Invalid Version');

    } else if (!(obj.message === null || obj.message.match(/^ *$/) !== null)) {
        if (!(obj.message.match(regexMessage)[0] === obj.message)) {
            throw new Error('Invalid request header: Invalid Message');
        }
    }
    return obj;
}

solve({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
  })