// include Fake libs
#I @"..\..\tools\FAKE"
#r "FakeLib.dll"
open Fake 

// Properties
let buildDir = @".\build\"
let deployDir = @".\deploy\"

Target "Deploy" (fun _ ->
    !+ (buildDir + "\**\*.*") 
        -- "*.zip" 
        |> Scan
        |> Zip buildDir (deployDir + "EmailGatewayService.zip")
)
// start build
Run "Deploy"