DROP TABLE #mytemp;
DROP TABLE #myPublicationLinks;

DELETE FROM _ObjectAuthorLinks;
DELETE FROM _ObjectAuthorLinks WHERE REL_ObjectType1 = 'discussion' OR REL_ObjectType2 = 'discussion';

DECLARE @au_id bigint
DECLARE @obj_type nchar(30)
DECLARE @t_id bigint
DECLARE @t_type nchar(30)


set rowcount 0
select * into #mytemp from Discussions;

set rowcount 1


select @au_id = Id, @obj_type = ObjectType from #mytemp


DECLARE @ri int;



while @@rowcount <> 0
begin
    set rowcount 0
--    select * from #mytemp where au_id = @au_id
	SET @ri = @au_id % 2 + 1
	
	SET rowcount @ri
	SELECT * INTO #myPublicationLinks FROM Users ORDER BY NEWID()
	
	SET rowcount 0
	
	while @ri > 0
	begin
		SET rowcount 1
		SELECT @t_id = Id, @t_type = ObjectType FROM #myPublicationLinks 
		SET rowcount 0
		DELETE FROM #myPublicationLinks WHERE Id = @t_id
		
		INSERT INTO _ObjectAuthorLinks VALUES(@au_id, @obj_type, @t_id, @t_type)
		INSERT INTO _ObjectAuthorLinks VALUES(@t_id, @t_type, @au_id, @obj_type)
		
		SET @ri = @ri - 1
	end
	DROP TABLE #myPublicationLinks;
	
    delete #mytemp where Id = @au_id

    set rowcount 1
    select @au_id = Id, @obj_type = ObjectType from #mytemp
end
set rowcount 0