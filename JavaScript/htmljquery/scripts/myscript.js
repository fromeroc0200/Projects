function testJquery() {
    var self = this;

    self.$content = $('.content').first();
    console.log(self.$content);

    self.$content.find('a').click(function() {
        var obj = this;
        //console.log(obj);
        //alert('click');
        obj.classList.toggle('row');
    });

}