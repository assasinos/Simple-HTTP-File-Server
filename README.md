# Simple-HTTP-File-Server 
is a simple server written in `C#(ASP.NET)` that allows uploading and downloading via HTTP/S.


## File Storage

Files are stored in Root folder `(wwwroot/Files)`
It supports only small files, uploading is done using `buffered model binding to physical storage` and has no security features.

## Ports

`HTTP - :5000`
`HTTPS - :5001`

## Running

Launch `.exe` or `.dll` file with --urls "`IP`" parameter, while being in folder that contains `wwwroot` folder.

Change `IP` to addreses that you want to support for example "`http://192.168.1.2:5000`".
You can add multiple IPs just add `;` between them.
