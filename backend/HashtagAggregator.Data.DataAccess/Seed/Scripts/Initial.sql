BEGIN
	DECLARE @parentTag nvarchar(30) = 'somesmallmessagefortestX';
	DECLARE @tag1 nvarchar(30) = 'somesmallmessagefortestXsell';
	DECLARE @tag2 nvarchar(30) = 'somesmallmessagefortestXbuy';
	DECLARE @tag3 nvarchar(30) = 'somesmallmessagefortestXcar';

	IF NOT EXISTS( SELECT Id from Hashtags WHERE HashTag = @parentTag)	
		INSERT Hashtags (HashTag, IsEnabled, ParentId)  VALUES(@parentTag, 1, NULL)

	DECLARE @parentId INT;
	SELECT @parentId = Id from Hashtags WHERE HashTag = @parentTag 

	IF NOT EXISTS( SELECT Id from Hashtags WHERE HashTag = @tag1)
		BEGIN
			INSERT Hashtags (HashTag, IsEnabled, ParentId)  VALUES(@tag1, 1, @parentId)
			INSERT Hashtags (HashTag, IsEnabled, ParentId)  VALUES(@tag2, 1, @parentId)
			INSERT Hashtags (HashTag, IsEnabled, ParentId)  VALUES(@tag3, 1, @parentId)
		END
END
