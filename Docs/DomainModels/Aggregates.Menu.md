# Domain Models

## Menu

```csharp
public class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
    // TODO: Add remaining methods
}
```

```json
{
    "id": {"value": "00000000-0000-0000-0000-000000000000"},
    "name": "Yummy Menu",
    "description": "My menu with yummy food",
    "averagerating": 4.5,
    "sections": [
        {
            "id": {"value": "00000000-0000-0000-0000-000000000000"},
            "name": "Appetizers",
            "description": "Starters",
            "items": [
                {
                    "id": {"value": "00000000-0000-0000-0000-000000000000"} ,
                    "name": "Fried Pickles",
                    "description": "Deep fried pickles",
                }
            ]
        }
    ],
    "hostid": {"value": "00000000-0000-0000-0000-000000000000"},
    "dinnerids": [{"value": "00000000-0000-0000-0000-000000000000"}],
    "menureviewids": [{"value": "00000000-0000-0000-0000-000000000000"}],
    "createddatetime": "2024-01-01T00:00:00",
    "updateddatetime": "2024-01-01T00:00:00"
}
```

