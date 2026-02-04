# REdoing the Vendors API

- All we need is
    - A way to get a "read model" of the list of vendors for the UI or whatever.

```json
[
    {
      "id": "b1d6f5a1-3f49-4b14-9b6b-0c1d0a1f0001",
      "name": "Microsoft"
    }
]
```

An "internal" way for the Catalog API to get this information to see if a vendor exists.


# A Couple Patterns in Distributed Applications

- Event Sourcing

- Command/Query Responsibility Segregation (CQRS)