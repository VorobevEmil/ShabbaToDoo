Чтобы запустить приложение, необходимо добавить строку подключения к базе данных. Для этого выполните следующие действия:

- Откройте терминал.
- Перейдите в папку проекта ShabbaToDoo.Api.
- Выполните команду "dotnet user-secrets init".
- Выполните команду "dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=ShabbaToDoo;Username=postgres;Password=пароль_от_postgres".