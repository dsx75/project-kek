# Meta Database


## Location

[Meta Folder](../../folders/meta-folder/)\\meta.db

## Tables

### Accounts

### Clients

### Rulesets

### Selected

| Column  | Data Type | Nullable | Notes |
| ------- | --------- | -------- | ----- |
| id  | Intereger | no | There's only one row in this table, with ID = 1 |
| id_client | Integer | yes | ID of the currently selected Client or null |
| id_world_version | Integer | yes | ID of the currently selected World Version or null |
| id_ruleset | Integer | yes | ID of the currently selected Ruleset or null |
| id_world | Integer | yes | ID of the currently selected World or null |

### World Versions

### Worlds
