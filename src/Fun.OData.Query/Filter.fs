[<AutoOpen>]
module Fun.OData.Query.Filter

    let combineFilter operator filters =
        filters
        |> Seq.map (sprintf "(%s)")
        |> String.concat (sprintf " %s " operator)

    let andQueries filters = combineFilter "and" filters
    let orQueries  filters = combineFilter "or" filters

    let gt name value       = sprintf "%s gt %s" name (string value)
    let lt name value       = sprintf "%s lt %s" name (string value)
    let eq name value       = sprintf "%s eq %s" name (string value)
    let contains name value = sprintf "contains(%s, '%s')" name value
