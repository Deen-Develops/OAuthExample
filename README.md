# OAuth

After downloading the code, you have to change sslPort in the **launchSettings.json** to 44350.

Example:

```
{
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:32378",
      "sslPort": 5000
    }
    
```

Change to:

```
{
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:32378",
      "sslPort": 44350
    }
    
```
