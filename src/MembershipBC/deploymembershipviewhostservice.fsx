// include Fake libs
#I @"..\..\tools\FAKE"
#r "FakeLib.dll"
open Fake 

// Properties
let buildDir = @".\build\MembershipViewHostService\output\"
let deployDir = @".\deploy\"

Target "Deploy" (fun _ ->
    !+ (buildDir + "\**\*.*") 
        -- "*.zip" 
        |> Scan
        |> Zip buildDir (deployDir + "MembershipViewHostService.zip")
)
// start build
Run "Deploy"