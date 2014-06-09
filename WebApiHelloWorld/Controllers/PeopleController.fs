namespace WebApiHelloWorld.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Net
open System.Net.Http
open System.Web
open System.Web.Http
open System.Web.SessionState
open WebApiHelloWorld.Models

type PeopleController() =
    inherit ApiController()

    let session = SessionStateUtility.GetHttpSessionStateFromContext(HttpContext.Current)
    let people = session.["people"] :?> array<People>

    do  
      if session.["people"] = null then
        session.["people"] <- [|
                                { Id = Guid.NewGuid().ToString().Replace("-", ""); FullName = "Frank Hale"; Age = 39 };
                                { Id = Guid.NewGuid().ToString().Replace("-", ""); FullName = "John Doe"; Age = 29 };
                                { Id = Guid.NewGuid().ToString().Replace("-", ""); FullName = "Steve Smith"; Age = 43 };
                                { Id = Guid.NewGuid().ToString().Replace("-", ""); FullName = "Dave Jones"; Age = 56 };
                              |]

    member x.Get() = 
      session.["people"] :?> array<People>
    
    member x.Get(id) = 
      if id < people.Length && id >= 0 then
         people.[id]
      else
        failwith "Person does not exist"

    member x.Delete([<FromBody>] d : Delete) =
      if x.ModelState.IsValid then
        session.["people"] <- people |> Array.filter (fun p -> p.Id <> d.Id)
        x.Request.CreateResponse<Delete>(HttpStatusCode.OK, d)
      else
        x.Request.CreateResponse<Delete>(HttpStatusCode.BadRequest, d)

    member x.Post([<FromBody>] p : People) =
      if x.ModelState.IsValid then
        session.["people"] <- Array.append people [| { Id = Guid.NewGuid().ToString().Replace("-", ""); FullName = p.FullName; Age = p.Age}; |]
        x.Request.CreateResponse<People>(HttpStatusCode.Created, p)
      else
        x.Request.CreateResponse<People>(HttpStatusCode.BadRequest, p)