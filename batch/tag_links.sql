DROP TABLE #mytemp;
DROP TABLE #mytags;

DELETE FROM _TagLinks;

DECLARE @au_id bigint
DECLARE @obj_type nchar(30)
DECLARE @t_id bigint
DECLARE @t_type nchar(30)


set rowcount 0
select * into #mytemp from Articles;

set rowcount 1


select @au_id = Id, @obj_type = ObjectType from #mytemp


DECLARE @ri int;



while @@rowcount <> 0
begin
    set rowcount 0
--    select * from #mytemp where au_id = @au_id
	SET @ri = @au_id % 4 + 1
	
	SET rowcount @ri
	SELECT * INTO #mytags FROM Tags ORDER BY NEWID()
	
	SET rowcount 0
	
	while @ri > 0
	begin
		SET rowcount 1
		SELECT @t_id = Id, @t_type = ObjectType FROM #mytags 
		SET rowcount 0
		DELETE FROM #mytags WHERE Id = @t_id
		
		INSERT INTO _TagLinks VALUES(@au_id, @obj_type, @t_id, @t_type)
		INSERT INTO _TagLinks VALUES(@t_id, @t_type, @au_id, @obj_type)
		
		SET @ri = @ri - 1
	end
	DROP TABLE #mytags;
	
    delete #mytemp where Id = @au_id

    set rowcount 1
    select @au_id = Id, @obj_type = ObjectType from #mytemp
end
set rowcount 0