var MenuList = [
    {
        parentMenu: "首页", cssFont: "glyphicon glyphicon-retweet", childrenMenu: [
            { url: "/Home/Index", name: "首页", navName: "BasicSet", fontCss: "glyphicon glyphicon-folder-close" },
        ]
    },
    {
        parentMenu: "广告计划管理", cssFont: "glyphicon glyphicon-share", childrenMenu: [
            { url: "/Home/Index", name: "广告素材列表", navName: "MyMessage", fontCss: "glyphicon glyphicon-saved" },
            { url: "/Home/Index", name: "广告计划列表", navName: "PayInfo", fontCss: "glyphicon glyphicon-saved" }]
    },
    {
        parentMenu: "财务管理", cssFont: "	glyphicon glyphicon-tasks", childrenMenu: [
            { url: "/Home/Index", name: "财务信息", navName: "MyCollect", fontCss: "glyphicon glyphicon-wrench" },
        ]
    },
    {
        parentMenu: "系统管理", cssFont: "	glyphicon glyphicon-tasks", childrenMenu: [
            { url: "/Home/Index", name: "基本信息", navName: "MyCollect", fontCss: "glyphicon glyphicon-wrench" },
        ]
    },
    {
        parentMenu: "退出", cssFont: "	glyphicon glyphicon-tasks", parentUrl:"/Home/Index", childrenMenu: [
           
        ]
    }
];

$(function () {
    var data = { menuList: MenuList };
    $("#MneuListTmpl").tmpl(data).appendTo('#menuall');
});