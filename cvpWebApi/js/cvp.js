﻿function OnFail(result) {
    window.location.href = "http://localhost:59955/genericError.html";
}

//function gcpUrl() {
//    return 'http://localhost:59955/handler/';
//}

var gcpUrl = "http://localhost:59955/handler/";

function formatdate(data) {
    var data = data.replace("/Date(", "").replace(")/", "");
    if (data.indexOf("+") > 0) {
        data = data.substring(0, data.indexOf("+"));
    }
    else if (data.indexOf("-") > 0) {
        data = data.substring(0, data.indexOf("-"));
    }
    var date = new Date(parseInt(data, 10));
    var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
    var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
    return date.getFullYear() + "-" + month + "-" + currentDate;
}


function displayDate(date) {
    var date = new Date(date.match(/\d+/)[0] * 1);
    var day = (date.getDate() < 10 ? '0' : '') + date.getDate();
    var month = ((date.getMonth() + 1) < 10 ? '0' : '') + (date.getMonth() + 1);
    var year = date.getFullYear();
    return (year + "-" + month + "-" + day);
}

function displayAddress(data) {
    var address;
    if ($.trim(data.street) == '') {
        return "";
    }
    address = data.street + "<br />";

    if (data.city != '') {
        address += data.city + ", ";
    }
    if (data.province != '') {
        address += data.province + "<br />"
    }
    if (data.country != '') {
        address += data.country;
    }
    if (data.postalCode != '') {
        address += ", " + data.postalCode;
    }
    if (address != '') {
        address = address.replace("undefined", "");
        return address;
    }
    return "&nbsp;";
}

function displayTableList(data, lang) {
    if (data.length == 0) {
        return "";
    }
    var txt = "";
    var i;
    for (i = 0; i < data.length; i++) {
        if ($.trim(data[i].insStartDate) != '') {
            txt += "<tr><td>" + formatdate(data[i].insStartDate) + "</td>";
        }
        if ($.trim(data[i].rating) != '' || $.trim(data[i].rating) == '') {
            if ($.trim(data[i].rating) != '') {
                if (data[i].rating.toLowerCase().indexOf("inspection") >= 0) {

                    txt += "<td><a href=initialReportCard-" + lang + ".html?lang=" + lang + "&gcpid=" + data[i].gcpID + ">" + data[i].rating + "</a></td>";
                }
                else {
                    if (data[i].reportCard) {
                        txt += "<td><a href=fullReportCard-" + lang + ".html?lang=" + lang + "&gcpid=" + data[i].gcpID + ">" + data[i].rating + "</a></td>";
                    }
                    else {
                        txt += "<td>" + data[i].rating + "</td>";
                    }
                }
            }
            else {
                txt += "<td></td>";
            }
        }
        if ($.trim(data[i].insType) != '') {
            txt += "<td>" + data[i].insType + "</td></tr>";
        }
    }

    if (txt != '') {
        txt = txt.replace("undefined", "");
        return txt;
    }
    return "&nbsp;";
}

function displayOrderedList(data) {
    var displaySummary;
    if ($.trim(data) == '') {
        return "";
    }
    $.each(data, function (index, record) {
        displaySummary += "<li>" + record + "</li>";
    });

    if (displaySummary != '') {
        displaySummary = displaySummary.replace("undefined", "");
        return "<ul>" + displaySummary + "</ul>";;
    }
    return "";
}

function displayOutcomeList(data) {
    var displaySummary;
    if ($.trim(data) == '') {
        return "";
    }
    $.each(data, function (index, record) {
        if (index % 2 == 0) {
            displaySummary += record + "<br /><br />";
        }
        else {
            displaySummary += record;
        }
    });
    if (displaySummary != '') {
        displaySummary = displaySummary.replace("undefined", "");
        return displaySummary;
    }
    return "";
}

function formatedSummaryList(data) {
    var displaySummary;
    if ($.trim(data) == '') {
        return "";
    }

    $.each(data, function (index, record) {
        displaySummary += "<li>" + record + "</li>";
    });

    if (displaySummary != '') {
        displaySummary = displaySummary.replace("undefined", "");
        return "<ul>" + displaySummary + "</ul>";;
    }
    return "";
}

function displayRating(data, lang) {
    if ($.trim(data.rating) == '') {
        return "";
    }
    if (data.rating.toLowerCase().indexOf("in") >= 0) {
        return '<a href=initialReportCard-' + lang + '.html?lang=' + lang + '&gcpid=' + data.gcpID + '>' + data.rating + '</a>';
    }
    else {
        if (data.reportCard) {
            return '<a href=fullReportCard-' + lang + '.html?lang=' + lang + '&gcpid=' + data.gcpID + '>' + data.rating + '</a>';
        }
    }
    return data.rating;
}


function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
    // below is from Janyoung's code
    //function getParameterByName(name) {
    //    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    //    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
    //        results = regex.exec(location.search);
    //    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    //}
}

function getURLParameter(sParam)
{
    var sPageURL = window.location.search.substring(1);
    var sURLVariables = sPageURL.split('&');
    for (var i = 0; i < sURLVariables.length; i++)
    {
        var sParameterName = sURLVariables[i].split('=');
        if (sParameterName[0] == sParam)
        {
            if (sParameterName[0] == sParam) {
                return sParameterName[1] == undefined ? true : sParameterName[1];
            }
        }
    }
}
