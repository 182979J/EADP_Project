CREATE TABLE [dbo].[JE_TDTGInfo] (
    [Id]            VARCHAR (100)  NOT NULL,
    [TGName]        VARCHAR (60)   NULL,
    [TGFirstName]   VARCHAR (30)   NULL,
    [TGLastName]    VARCHAR (30)  NULL,
    [TGMobile]      INT            NULL,
    [TGEmail]       VARCHAR (100)  NULL,
	[TGProfilePic]  NVARCHAR(MAX)          NULL,
    [Nric_front]    NVARCHAR(MAX)         NULL,
    [Nric_back]     NVARCHAR(MAX)           NULL,
    [License_front] NVARCHAR(MAX)           NULL,
    [License_back]  NVARCHAR(MAX)           NULL,
    [ACRA1]         NVARCHAR(MAX)           NULL,
    [ACRA2]         NVARCHAR(MAX)           NULL,
    [ACRA3]         NVARCHAR(MAX)           NULL,
    [Type_of_bank]  NCHAR (20)    NULL,
    [Bank_num]      INT           NULL,
	
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

