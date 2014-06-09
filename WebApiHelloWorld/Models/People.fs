namespace WebApiHelloWorld.Models

open Newtonsoft.Json
open System.Runtime.Serialization

[<CLIMutable>]
[<JsonObject(MemberSerialization=MemberSerialization.OptOut)>]
type Delete = {
  Id : string
}

[<CLIMutable>]
[<JsonObject(MemberSerialization=MemberSerialization.OptOut)>]
type People = {
  Id : string
  FullName : string
  Age : int
}