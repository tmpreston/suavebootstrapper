# suavebootstrapper

[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/)

1) run `build.cmd` and it will
  * download latest paket.exe
  * download all packages from paket.dependencies:
      * FAKE (which is like an fsi)
      * suave
  * it starts FAKE
  * and FAKE starts suave at port 8083
 
or 

2) run `build.cmd port=1000` to do the same on port 1000

This example last hosted on Azure -> [here](http://suavebootstrapper3f25.azurewebsites.net/)
