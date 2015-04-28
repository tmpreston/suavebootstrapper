// Step 0. Boilerplate to get the paket.exe tool
 
open System
open System.IO
 
Environment.CurrentDirectory <- __SOURCE_DIRECTORY__
 
if not (File.Exists "paket.exe") then
let url = "https://github.com/fsprojects/Paket/releases/download/0.31.5/paket.exe"
use wc = new Net.WebClient() in let tmp = Path.GetTempFileName() in wc.DownloadFile(url, tmp); File.Move(tmp,Path.GetFileName url)
 
// Step 1. Resolve and install the packages
 
#r "paket.exe"
 
Paket.Dependencies.Install """
source https://nuget.org/api/v2
nuget Suave
nuget FSharp.Data
nuget FSharp.Charting
""";;
 
// Step 2. Use the packages
 
#r "packages/Suave/lib/net40/Suave.dll"
#r "packages/FSharp.Data/lib/net40/FSharp.Data.dll"
#r "packages/FSharp.Charting/lib/net40/FSharp.Charting.dll"
 
let ctxt = FSharp.Data.WorldBankData.GetDataContext()
 
let data = ctxt.Countries.Algeria.Indicators.``GDP (current US$)``
 
open Suave // always open suave
open Suave.Http.Successful // for OK-result
open Suave.Web // for config
 
startWebServer defaultConfig (OK (sprintf "Hello World! (example from http://suave.io/ ) In 2010 Algeria earned %f " data.[2010]))
