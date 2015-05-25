function CFilter($base) {

    var self = this;
    var bak = new CBak();
    // view generalWrap

    this.$mainFilter = $base;

    this.$generalWrap = self.$mainFilter.find('div.generalWrap');
    this.$tagList     = self.$mainFilter.find('dl.tagList');
    this.$buttons     = self.$mainFilter.find('div.buttonsBlock');

    this.$myChoice = self.$generalWrap.find('dl.myChoice');
    this.$bakList  = self.$myChoice.next('dl');

    this.$choiceList = self.$myChoice.find('dd:first');

    this.$sectionList    = self.$bakList.find('._section');
    this.$subSectionList = self.$bakList.find('._subSection');
    this.$categoryList   = self.$bakList.find('._category');
    this.$categoryUls    = self.$categoryList.find('ul');

    this.$btnSave = self.$buttons.find('span.ibutton:first');
    this.$btnCancel = self.$buttons.find('span.ibutton:last');

    this.$mainFilterOpener = $('._mainFilterOpener');

    this.$helpDescription = $('.topPanel dfn');

    //;

    /* prepare */
    //$choiceList.html('');
    /* prepare */

    /* view */
    // section
    this.BuildSection = function () {
        //var frag = document.createDocumentFragment();
        var list = bak.data;
        var $li;


        self.$sectionList.html('');

        for (var i = 0; i < list.length; i++) {

            $li = $('<li></li>')
            .attr('rel', list[i].Id)
            .html('<span>' + list[i].Header + '</span>' + ((i>0)?'<span class="add" title="Добавить область">Добавить</span>':'') );

            self.$sectionList.append($li);
        }

        self.$sectionList.find('li:first').addClass('choice');

        //BuildCategory();
        self.BuildSubSection();
    };

    // category
    this.BuildSubSection = function () {
        var rel = self.$sectionList.find('li.choice').attr('rel');
        var section = bak.getRubric(rel);
        if (section == null) return;
        var list = section.Children;

        

        var $li;

        var $uls = self.$categoryList.find('ul');


        self.$subSectionList.html('');

        for (var i = 0; i < list.length; i++) {

            $li = $('<li></li>')
                .attr('rel', list[i].Id)
                .html('<span>' + list[i].Header + '</span>' + ((i > 0) ? '<span class="add" title="Добавить область">Добавить</span>' : ''));

            self.$subSectionList.append($li);
        }

        self.$subSectionList.find('li:first').addClass('choice'); ;
        self.BuildCategory();
    };

    // category
    this.BuildCategory = function () {
        var rel = self.$subSectionList.find('li.choice').attr('rel');
        var section = bak.getRubric(rel);
        var list = section.Children;

        var $uls = self.$categoryList.find('ul');
        var j;


        self.$categoryUls.html('');

        j = 0;
        for (var i = 0; i < list.length; i++) {
            
            if (self.$choiceList.find('li._myCategory[rel=' + list[i].Id + ']').length > 0) {
                $uls.eq(j++)
				.append($('<li></li>').attr('rel', list[i].Id).addClass('select').html(list[i].Header + '<span class="add" title="Добавить категорию">Добавить</span>'));
            }
            else {
                $uls.eq(j++)
				.append($('<li></li>').attr('rel', list[i].Id).html(list[i].Header + '<span class="add" title="Добавить категорию">Добавить</span>'));
            }
            if (j == 3)
                j = 0;
        }
    };


    /* view */
    bak.loadStruct({
        load: function () {
            self.BuildSection();
        }
    });


    this.sectionHtml = function (_rel, _text, _level, _addChild) {
        return res = '<div class=" _node field ' + _level + '" rel="' + _rel + '"><ul class="sectionList borderAll10 ' + ((_addChild) ? "" : "show") + '" style="-webkit-user-select: none; ">'
                   + '<li class="choice"><span>' + _text + " <span class='_showAll' style='display: none'>(все)</span>"  + '</span></li>'
                   + '</ul><div class="delete" title="Удалить область">Удалить</div></div>';
    };

    this.catHtml = function (_rel, _text, _level) {
        return res = '<li class=" _node ' + _level + '" rel="' + _rel + '"><span>' + _text + '</span><span class="delete" title="Удалить область">Удалить</div></li>';
    };

    // section add
    this.addSection = function (_rel, _addChild) {
        var $existing = self.$choiceList.find('div[rel=' + _rel + ']');
        var rubric = bak.getRubric(_rel);

        if ($existing.length == 0 || _addChild) {
            if ($existing.length > 0) {
                $existing.remove();
                $existing = null;
            }
            $existing = $(self.sectionHtml(_rel, rubric.Header, '_mySection _selRubric', _addChild));
            self.$choiceList.append($existing);
        }

        if (_addChild == true) {
            for (var i = 0; i < rubric.Children.length; i++)
                this.addSubSection(rubric.Children[i].Id, true);
        }

        self.liveUpdateRubricFilter();
        return $existing;
    };


    // subsection add
    this.addSubSection = function (_rel, _addChild) {
        var rubric = bak.getRubric(_rel);
        var parent = rubric.Parent_Rubric_ID;
        var parentRubric = bak.getRubric(rubric.Parent_Rubric_ID);

        var $existing = self.addSection(parent, false);
        var $subExisting = $existing.find('div[rel=' + _rel + ']');


        if ($subExisting.length == 0 || _addChild) {
            if ($subExisting.length > 0) {
                $subExisting.parent().remove();
                $subExisting = null;
            }
            $subExisting = $('<li>' + self.sectionHtml(_rel, rubric.Header, '_mySubSection _selRubric', _addChild) + '</li>');
            $existing.find('ul').first().append($subExisting);
        }

        if (_addChild == true) {
            for (var i = 0; i < rubric.Children.length; i++)
                this.addCategory(rubric.Children[i].Id);
        }
        
        self.updateAllChildrenSelected($existing);
        self.liveUpdateRubricFilter();
        return $subExisting;
    };
    
    
    // category add
    this.addCategory = function (_rel) {
        var rubric = bak.getRubric(_rel);
        var parent = rubric.Parent_Rubric_ID;
        var parentRubric = bak.getRubric(rubric.Parent_Rubric_ID);

        var $existing = self.addSubSection(parent, false);
        var $catExisting = $existing.find('li[rel=' + _rel + ']');


        if ($catExisting.length == 0) {
            $catExisting = $(self.catHtml(_rel, rubric.Header, '_myCategory _selRubric'));
            $existing.find('ul').first().append($catExisting);
        }


        self.updateAllChildrenSelected($existing);
        //self.updateAllChildrenSelected($existing.closest('._mySection'));
        self.liveUpdateRubricFilter();
        return $catExisting;
    };

    this.updateAllChildrenSelected = function ($_obj, _nestedChildren) {
        if (self.isAllChildrenSelected($_obj)) {
            $_obj.find('._showAll').first().show();
            $_obj.addClass('_all');
        }
        else {
            $_obj.find('._showAll').first().hide();
            $_obj.removeClass('_all');
        }
    }

    this.isAllChildrenSelected = function ($_obj) {
        var _rubric = $_obj.attr('rel');
        if (!_rubric) return;
        _rubric = bak.getRubric(_rubric)
        if (!_rubric) return false;
        // check if the filter is fully loaded
        var i = 0;
        for (i = 0; i < _rubric.Children.length; ++i) {
            var childId = _rubric.Children[i].Id;
            var $c = $_obj.find('._node[rel=' + childId + ']');
            if ( ($c.length == 0) || (!self.isAllChildrenSelected($c)) ) {
                return false;
            }
        }
        //alert('yes');
        return true;
    }

    this.UPDATE_TIMER = null;

    this.invokeUpdateRubricFilter = function () {
        var $mod = self.$tagList.find('._module');
        if (!$mod.length) return;
        var params = MODULEPARAMS[$mod.attr('rel')];
        params['UserRubricFilter'] = self.getSelectedRubricsSemicolon();
        params['UserTagFilter'] = self.getSelectedTagsSemicolon();
        updateModule($mod);
    }

    this.liveUpdateRubricFilter = function () {
        //alert('aa');
        if (self.UPDATE_TIMER) {
            window.clearTimeout(self.UPDATE_TIMER);
            }
        this.UPDATE_TIMER = window.setTimeout(
            function () {
                self.invokeUpdateRubricFilter();
            }, 500);
    }

    this.$tagList.find('li').live('click', self.liveUpdateRubricFilter)
        /* events */
    this.getSelectedTagsSemicolon = function () {
        var rubrics = self.getSelectedRubrics();
        rubrics = rubrics['TagIDs'];
        var ar = new Array();
        for (var i in rubrics) ar.push(rubrics[i]);
        var res = ar.join(';');

        return res;
    }
    this.getSelectedRubricsSemicolon = function () {
        var rubrics = self.getSelectedRubrics();
        rubrics = rubrics['IDs'];
        var ar = new Array();
        for (var i in rubrics) ar.push(rubrics[i]);
        var res = ar.join(';');
        return res;
    }

    this.getSelectedRubrics = function () {
        var data = {};
        data['IDs'] = {};
        data['TagIDs'] = {};

        var $relsSec = self.$choiceList.find('._mySection').not('._all');
        var $relsSubSec = $relsSec.find('._mySubSection').not('._all');

        var $relsSecAll = self.$choiceList.find('._mySection._all');
        var $relsSubSecAll = $relsSec.find('._mySubSection._all');

        var $relsCat = $relsSubSec.find('._myCategory').add($relsSecAll).add($relsSubSecAll);

        for (var j = 0; j < $relsCat.length; ++j) {
            var ri = $relsCat.eq(j).attr('rel');
            data['IDs'][j] = ri;
        }

        var $tags = self.$tagList.find('.cur');

        for (var j = 0; j < $tags.length; ++j) {
            data['TagIDs'][j] = $tags.eq(j).attr('rel');
        }

        return data;
    }

    this.open = function () {
        self.$mainFilter.slideDown();
    }

    this.close = function () {
        self.$mainFilter.slideUp();
    }

    this.reset = function () {
    }

    // save

    self.$btnSave.click(function () {
        self.close();
        var data = self.getSelectedRubrics();
        $but = $(this);
        $but.parent().addClass('_preloader');
        $.ajax({
            type: 'POST',
            url: $but.attr('rel'),
            data: data,
            complete: function () {
                $but.parent().removeClass('_preloader');
            }
        });

    });

    this.CLOSING_TIMER = null;

    // cancel
    self.$btnCancel.click(function () {
        self.close();
    });

    self.$mainFilterOpener.hover(function () {
        self.$helpDescription.text('Щелкните по пункту "Моя подборка", чтобы применить фильтр');
        self.open();
    });

    self.$mainFilterOpener.click(function () {
        self.open();

        for (var i in MODULEPARAMS) {
            var p = MODULEPARAMS[i];
            if (p['UserFilter'] > 0) {
                var $mod = $('.' + p['ModuleId']);
                p['UserRubricFilter'] = self.getSelectedRubricsSemicolon();
                updateModule($mod);

            }
        }
    });

    self.$mainFilter.add(self.$mainFilterOpener).hover(
    function () {
        window.clearTimeout(self.CLOSING_TIMER);
        self.CLOSING_TIMER = null;
    },
    function () {
        if( self.CLOSING_TIMER ) window.clearTimeout(self.CLOSING_TIMER);
        self.CLOSING_TIMER = window.setTimeout(self.close, 600);
    });


    // select
    self.$mainFilter.find('._section').each(function () {
        var $ul = $(this);

        $ul.delegate('li', 'click', function () {
            var $li = $(this);
            $ul.find('li .add').css('visibility', '');

            if ($ul.hasClass('show'))
                $li.find('.add').css('visibility', 'hidden');
            if (!$li.hasClass('choice')) {
                $(this).switchSibClass('choice');
                self.BuildSubSection();
            }
            $ul.toggleClass('show');
        });

        $ul.delegate('.add', 'click', function () {
            var $add = $(this);
            var $li = $(this).parent('li');
            var rel = $li.attr('rel');

            self.addSection(rel, true);
        });
    });

    //
    self.$mainFilter.find('._addSection').click(function () {
        var rel = $(this).prev().find('.choice').attr('rel');
        self.$mainFilter.find('._category li').addClass('select');
        self.addSection(rel, true);
    });

    self.$mainFilter.find('._addSubSection').click(function () {
        var rel = $(this).prev().find('.choice').attr('rel');
        self.$mainFilter.find('._category li').addClass('select');
        self.addSubSection(rel, true);
    });

    // init
    self.$mainFilter.find('._subSection').each(function () {
        var $ul = $(this);

        $ul.delegate('li', 'click', function () {
            var $li = $(this);

            $ul.find('li .add').css('visibility', '');

            if ($ul.hasClass('show'))
                $li.find('.add').css('visibility', 'hidden');

            if (!$li.hasClass('choice')) {
                $(this).switchSibClass('choice');
                self.BuildCategory();
            }

            $ul.toggleClass('show');
        })

        .delegate('.add', 'click', function () {
            var $add = $(this);
            var $li = $add.parent('li');
            var rel = $li.attr('rel');

            self.addSubSection( rel, true );
        });

    });

    self.$mainFilter.find('._category').each(function () {
        var $ul = $(this);

        $ul.delegate('li', 'click', function () {
            $(this).addClass('select');
            self.addCategory(this.getAttribute('rel'));
        });
    });


    self.$choiceList.delegate('._selRubric .delete', 'click', function () {
        var $del = $(this);
        var $p = $del.parent();

        if ($p.hasClass('_mySection')) {
            if (self.$mainFilter.find('._section li.choice[rel=' + $p.attr('rel') + ']').length > 0) {
                self.$mainFilter.find('._category li.select').removeClass('select');
            }
            $p.remove();

            self.updateAllChildrenSelected($p);
            self.liveUpdateRubricFilter();
            return;
        }

        var $pp = $p.parent();

        if ($p.hasClass('_myCategory')) {
            self.$mainFilter.find('._category li.select[rel=' + $p.attr('rel') + ']').removeClass('select');
            var $sect = $p.closest('._mySection');
            var $cat = $p.closest('._mySubSection');
            $p.remove();
            self.updateAllChildrenSelected($cat);
            self.updateAllChildrenSelected($sect);

            var $title = $pp.find('li.choice span').first();
            if ($pp.find('._myCategory').length <= 0) {
                $p = $pp.parent();
                $pp = null;
                $pp = $p.parent();
            }
            else {
                self.liveUpdateRubricFilter();
                return;
            }
        }

        if ($p.hasClass('_mySubSection')) {
            if (self.$mainFilter.find('._subSection li.choice[rel=' + $p.attr('rel') + ']').length > 0) {
                self.$mainFilter.find('._category li.select').removeClass('select');
            }
            $cat = $p.closest('._mySection');
            var $titleCat = $pp.parent().find('li.choice span').first();
            $pp.remove();
            self.updateAllChildrenSelected($cat);


            if ($cat.find('li ._mySubSection').length <= 0) {
                $cat.remove();
            }
        }


        self.liveUpdateRubricFilter();
    });


    self.$myChoice.delegate('.clearSelection', 'click', function () {
        self.$choiceList.html('');
    })
    
    .delegate( 'ul.sectionList', 'click', function(ev){
        var $ul = $(this);

        ev.stopPropagation();

        $ul.toggleClass('show');
    });

}

function RubricEditor($base) {

    if ($base.length == 0) return;
    if ($base.html() == null) return;
    if (!$base.hasClass('selectRubric')) return;
    
    var self = this;
    var bak = new CBak();

    this.$mainEditor = $base;

    this.$sectionList = self.$mainEditor.find('._section');
    this.$subSectionList = self.$mainEditor.find('._subSection');
    this.$categoryList = self.$mainEditor.find('._category');
    this.$categoryUls = self.$categoryList.find('ul');

    this.$choiceList = self.$mainEditor.next().find('.rubricBlock');

    //Section
    this.BuildSection = function () {
        
        var list = bak.data;
        var $li;

        self.$sectionList.html('');

        for (var i = 0; i < list.length; i++) {

            $li = $('<li></li>')
            .attr('rel', list[i].Id)
            .html('<span>' + list[i].Header + '</span>');

            self.$sectionList.append($li);
        }

        self.$sectionList.find('li:first').addClass('choice');
                
        self.BuildSubSection();
    };

    // SubSection
    this.BuildSubSection = function () {
        var rel = self.$sectionList.find('li.choice').attr('rel');
        var section = bak.getRubric(rel);
        var list = section.Children;
        var $li;

        self.$subSectionList.html('');

        for (var i = 0; i < list.length; i++) {

            $li = $('<li></li>')
                .attr('rel', list[i].Id)
                .html('<span>' + list[i].Header + '</span>');

            self.$subSectionList.append($li);
        }

        self.$subSectionList.find('li:first').addClass('choice'); ;
        self.BuildCategory();
    };

    // category
    this.BuildCategory = function () {
        var rel = self.$subSectionList.find('li.choice').attr('rel');
        var section = bak.getRubric(rel);
        var list = section.Children;

        var $uls = self.$categoryList.find('ul');
        var j;


        self.$categoryUls.html('');

        j = 0;
        for (var i = 0; i < list.length; i++) {

            $uls.eq(j++)
				.append($('<li></li>').attr('rel', list[i].Id).html(list[i].Header + '<span class="add" title="Добавить категорию">Добавить</span>'));

            if (j == 3)
                j = 0;
        }
    };


    /* view */
    bak.loadStruct({
        load: function () {
            self.BuildSection();
        }
    });

    this.elementHtml = function (_rel, _text, _level, _rev, _deleted) {
        var deleteString = ((_deleted) ? "<span class=\"delete\" title=\"Удалить категорию\">Удалить</span>" : "");
        return res = '<span class="_id" rel="' + _rel + '" rev="' + _rev + '">' + ((_level != "_choiseSection") ? "//&nbsp;&nbsp;&nbsp;" : "") + _text + deleteString + '</span>';
    };

    this.sectionHtml = function (_rel, _text, _level, _rev, _deleted) {
        return res = '<div class="' + _level + '">' + self.elementHtml(_rel, _text, _level, _rev, _deleted) + '</div>';
    };

    
    
    // section add
    this.addSection = function (_rel) {
        var $existing = self.$choiceList.find('div._choiseSection span[rel=' + _rel + ']').parent();
        var rubric;

        if ($existing.length == 0) {
            rubric = bak.getRubric(_rel);

            $existing = $('<div class="line">' + self.sectionHtml(_rel, rubric.Header, '_choiseSection', rubric.ObjectType,false) + '</div>');
            self.$choiceList.append($existing);
            $existing = $existing.find('._choiseSection');
        }

        return $existing;
    };


    // subsection add
    this.addSubSection = function (_rel) {
        var rubric = bak.getRubric(_rel);
        var parent = rubric.Parent_Rubric_ID;

        var $existing = self.addSection(parent);

        var $subExisting = $existing.next('._choiseSubSection');
        if ($subExisting.length == 0) {
            $subExisting = $(self.sectionHtml(_rel, rubric.Header, '_choiseSubSection', rubric.ObjectType, true));
            $existing.after($subExisting);
        }
        
        var $subExistingElement = $subExisting.find('span[rel=' + _rel + ']');

        if ($subExistingElement.length == 0) {
            $subExistingElement = $(self.elementHtml(_rel, rubric.Header, '_choiseSubSection', rubric.ObjectType, true));
            $subExisting.append($subExistingElement);
        }

        return $subExistingElement;
    };


    // category add
    this.addCategory = function (_rel) {
        var rubric = bak.getRubric(_rel);
        var parent = rubric.Parent_Rubric_ID;

        var $existing = self.addSubSection(parent);
        var $subExisting = $existing.next('._choiseCategory');
        if ($subExisting.length == 0) {
            $subExisting = $(self.sectionHtml(_rel, rubric.Header, '_choiseCategory', rubric.ObjectType, true));
            $existing.after($subExisting);
        }

        var $catExisting = $subExisting.find('span[rel=' + _rel + ']');


        if ($catExisting.length == 0) {
            $catExisting = $(self.elementHtml(_rel, rubric.Header, '_choiseCategory', rubric.ObjectType, true));
            $subExisting.append($catExisting);
        }

        var $r = $('.addRubric .categoryList li[rel=' + _rel + ']');
        $r.addClass('select');
        return $catExisting;
    };


    /*select*/
    self.$mainEditor.find('._section').each(function () {
        var $ul = $(this);

        $ul.delegate('li', 'click', function () {
            var $li = $(this);
            if(self.$subSectionList.hasClass('show'))
                self.$subSectionList.toggleClass('show');        
            if (!$li.hasClass('choice')) {
                $(this).switchSibClass('choice');
                self.BuildSubSection();
            }
            $ul.toggleClass('show');
        });

    });
    self.$mainEditor.find('._subSection').each(function () {
        var $ul = $(this);

        $ul.delegate('li', 'click', function () {
            var $li = $(this);
            if (self.$sectionList.hasClass('show'))
                self.$sectionList.toggleClass('show');
            if (!$li.hasClass('choice')) {
                $(this).switchSibClass('choice');
                self.BuildCategory();
            }

            $ul.toggleClass('show');
        })
    });
    self.$mainEditor.find('._category').each(function () {
        var $ul = $(this);

        $ul.delegate('li', 'click', function () {
            self.addCategory(this.getAttribute('rel'));
        });
    });

    self.$choiceList.delegate('._choiseSubSection .delete', 'click', function () {

        var $delBut = $(this);
        var _rel = $(this).parents('._id').first().attr('rel');
        var $r = $('.addRubric .categoryList li[rel=' + _rel + ']');
        $r.removeClass('select');

        var $choiseCategory = $delBut.closest('._choiseCategory');
        if ($choiseCategory.length > 0) {
            $delBut.parent().remove();
            if ($choiseCategory.find('span').length <= 0) {
                var $subCategory = $choiseCategory.prev();
                var $subSection = $choiseCategory.parent();
                $subCategory.remove();
                $choiseCategory.remove();
                if ($subSection.find('span').length <= 0 && $subSection.find('div').length <= 0) {
                    $subSection.parent().remove();
                }
            }
        }
        else {
            $choiseCategory = $delBut.parent().next('._choiseCategory');
            var $subSection = $delBut.closest('._choiseSubSection');
            $choiseCategory.remove();
            $delBut.parent().remove();
            if ($subSection.find('span').length <= 0 && $subSection.find('div').length <= 0) {
                $subSection.parent().remove();
            }
        }

    });
}