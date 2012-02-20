// include Fake libs
#I @"..\..\tools\FAKE"
#r "FakeLib.dll"
open Fake 

// Properties
let buildDir = @".\build\MembershipHostService\output\"
let deployDir = @".\deploy\"

Target "Deploy" (fun _ ->
    !+ (buildDir + "\**\*.*") 
        -- "*.zip" 
        |> Scan
        |> Zip buildDir (deployDir + "MembershipHostService.zip")
)
// start build
Run "Deploy"