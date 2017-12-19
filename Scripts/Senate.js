/**
 * Created by Administrator on 2017/12/11.
 */
var button_create = document.getElementById('button_create');
var button_submit = document.getElementById('button_submit');
var button_delete = document.getElementById('button_delete');
var nav = document.getElementsByClassName('choose')[0];
var nav_a = nav.getElementsByTagName('a');
var editText = null;
for(var i=0; i<nav_a.length; i++) {
    if(nav_a[0].style.color == 'blue') {
        editText = ['修改', '冻结', '重置口令'];
        break;
    } else {
        editText = ['修改'];
        break;
    }
}

button_create.addEventListener("click", (function () {
    return function () {
        new Create(editText).create();
    }
})(), false);
button_submit.addEventListener("click", (function () {
    return function () {
        new Submit(editText).submit();
    }
})(), false);
button_delete.addEventListener("click", (function () {
    return function () {
        new Delete().delete();
    }
})(), false);
