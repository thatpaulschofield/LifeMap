// include Fake libs
#I @"..\..\tools\FAKE"
#r "FakeLib.dll"
open Fake 

// Properties
let buildDir = @"build\"
let appReferences = !+ @".\LifeMap.EmailGateway\LifeMap.EmailGateway.csproj" |> Scan
let deployDir = @"deploy\"

// Targets
Target? Clean <-
    fun _ -> CleanDir buildDir
 
Target? BuildApp <-
  fun _ ->
    let target = "Build"
    // compile all projects below src/app/ in Release mode
    let apps = MSBuildDebug buildDir target appReferences
    // log the output files
    Log "AppBuild-Output: " apps
    
Target? Default <-
    fun _ -> trace "Hello World from FAKE"

// Dependencies
For? BuildApp <- Dependency? Clean
For? Default <- Dependency? BuildApp

// start build
Run "Default"