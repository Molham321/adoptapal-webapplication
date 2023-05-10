IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230510083943_Initial')
BEGIN
    CREATE TABLE [Address] (
        [Id] uniqueidentifier NOT NULL,
        [Street] nvarchar(max) NOT NULL,
        [StreetNumber] nvarchar(max) NOT NULL,
        [City] nvarchar(max) NOT NULL,
        [Zip] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Address] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230510083943_Initial')
BEGIN
    CREATE TABLE [Notizen] (
        [Id] uniqueidentifier NOT NULL,
        [Content] nvarchar(256) NOT NULL,
        CONSTRAINT [PK_Notizen] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230510083943_Initial')
BEGIN
    CREATE TABLE [Nutzer] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [ConfirmPassword] nvarchar(max) NOT NULL,
        [AddressId] uniqueidentifier NULL,
        CONSTRAINT [PK_Nutzer] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Nutzer_Address_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Address] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230510083943_Initial')
BEGIN
    CREATE INDEX [IX_Nutzer_AddressId] ON [Nutzer] ([AddressId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230510083943_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230510083943_Initial', N'7.0.5');
END;
GO

COMMIT;
GO

