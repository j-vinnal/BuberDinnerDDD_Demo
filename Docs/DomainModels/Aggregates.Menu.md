# Domain Models

## Menu

```csharp
public class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Yummy Menu",
    "description": "My menu with yummy food",
    "averagerating": 4.5,
    "sections": [
        {
            "id": "00000000-0000-0000-0000-000000000000",
            "name": "Appetizers",
            "description": "Starters",
            "items": [
                {
                    "id": "00000000-0000-0000-0000-000000000000",
                    "name": "Fried Pickles",
                    "description": "Deep fried pickles",
                    "price": 10.00  
                }
            ]
        }
    ],
    "createddatetime": "2024-01-01T00:00:00",
    "updateddatetime": "2024-01-01T00:00:00",
    "hostid": "00000000-0000-0000-0000-000000000000",
    "dinnerids": ["00000000-0000-0000-0000-000000000000"],
    "menureviewids": ["00000000-0000-0000-0000-000000000000"]
}
```

