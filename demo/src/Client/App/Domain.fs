namespace rec Client.App

open System
open Fun.LightForm
open Dtos.DemoData


type State =
  { ErrorInfo: string option
    IsLoading: bool
    FilterForm: LightForm
    TotalCount: int
    Data: DemoDataBrief list
    Detail: DemoData option
    ODataQuery: string option }

type Msg =
  | OnError of string option
  | FilterFormMsg of LightFormMsg
  | LoadData
  | LoadedData of ODataResult<DemoDataBrief>

  | LoadDataById of int
  | LoadedDataById of DemoData


type Filter =
  { PageSize: int
    Page: int
    SearchName: string option
    MinPrice: decimal option
    FromCreatedDate: DateTime option
    ToCreatedDate: DateTime option
    QueryType : QueryType }
  static member defaultValue =
    { PageSize = 5
      Page = 1
      SearchName = None
      MinPrice = None
      FromCreatedDate = None
      ToCreatedDate = None
      QueryType = QueryType.Simple }

type QueryType =
  | Simple
  | Pro
  | Fluent
  static member toQueryString = function
    | QueryType.Simple -> "demo"
    | QueryType.Fluent -> "demofluent"
    | QueryType.Pro    -> "demopro"

type DemoDataBrief =
  { Id: int
    Name: string
    Price: decimal
    CreatedDate: DateTime }