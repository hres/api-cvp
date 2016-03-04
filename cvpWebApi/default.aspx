﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html>
<!--[if lt IE 9]><html class="no-js lt-ie9" lang="<bean:message bundle='clfRes' key='label.app.lang'/>" dir="ltr"><![endif]--><!--[if gt IE 8]><!-->
<html class="no-js" lang="en" dir="ltr">
<!--<![endif]-->
<head>
    <meta charset="utf-8">

    <script>
       function scrollToContent (){window.location.hash="wb-cont";}
       function noScrollToContent (){}
    </script>

    <!-- Web Experience Toolkit (WET) / Boite a  outils de l'exp退rience Web (BOEW)
            wet-boew.github.io/wet-boew/License-en.html / wet-boew.github.io/wet-boew/Licence-fr.html -->
    <!-- TITLE BEGINS | DEBUT DU TITRE -->
    <title>Canada Vigilance Adverse Reaction Database - APIs</title>
    <!-- TITLE ENDS | FIN DU TITRE -->
    <!-- METADATA BEGINS | DEBUT DES METADONNEES -->
    <!--<c:import url="/layout/metaData.jsp" />-->
    <!-- METADATA ENDS | FIN DES METADONNEES -->
    <!--[if gte IE 9 | !IE ]><!-->
    <link href="./distro/4.0.19/assets/favicon.ico" rel="icon"
          type="image/x-icon">
    <link rel="stylesheet" href="./distro/4.0.19/css/wet-boew.min.css">
    <link rel="stylesheet" href="./distro/4.0.19/css/theme.min.css">
    <link rel="stylesheet"
          href="//netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" />
    <!--<![endif]-->
    <!--[if lt IE 9]>
            <link href="./distro/4.0.19/assets/favicon.ico" rel="shortcut icon" />
            <link rel="stylesheet" href="./distro/4.0.19/css/ie8-wet-boew.min.css" />
            <link rel="stylesheet" href="//netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" />
            <![endif]-->

    <noscript>
        <link rel="stylesheet" href="./distro/4.0.19/css/noscript.min.css" />
    </noscript>
    <script>dataLayer1 = [];</script>
</head>
<body vocab="http://schema.org/" typeof="WebPage">

    <!-- Google Tag Manager -->
    <script src="./distro/4.0.19/js/jquery-2.1.1.min.js"></script>
    <!-- Only for developpement, delete for production -->
    <noscript>
        <iframe title="Google Tag Manager"
                src="//www.googletagmanager.com/ns.html?id=GTM-TLGQ9K" height="0"
                width="0" style="display: none; visibility: hidden"></iframe>
    </noscript>

    <script>
	(function(w, d, s, l, i) {
		w[l] = w[l] || [];
		w[l].push({
			'gtm.start' : new Date().getTime(),
			event : 'gtm.js'
		});
		var f = d.getElementsByTagName(s)[0], j = d.createElement(s), dl = l != 'dataLayer1' ? '&l='
				+ l
				: '';
		j.async = true;
		j.src = '//www.googletagmanager.com/gtm.js?id=' + i + dl;
		f.parentNode.insertBefore(j, f);
	})(window, document, 'script', 'dataLayer1', 'GTM-TLGQ9K');
    </script>
    <!-- End Google Tag Manager -->

    <ul id="wb-tphp">
        <li class="wb-slc">
            <a class="wb-sl" href="#wb-cont">Skip to main content</a>
            <a class="wb-sl" href="#wb-cont">Passer au contenu principal</a>
        </li>
        <li class="wb-slc visible-sm visible-md visible-lg">
            <a class="wb-sl" href="#wb-info">Skip to "About this site"</a>
        </li>
    </ul>
    <!-- HEADER BEGINS  | DEBUG DE L'EN-TETE -->
    <header role="banner">
        <div id="wb-bnr" class="container">
            <section id="wb-lng" class="visible-md visible-lg text-right">
                <h2 class="wb-inv">Language selection</h2>
                <div class="row">
                    <div class="col-md-12">
                        <ul class="list-inline margin-bottom-none">
                            <li>
                                <a lang="fr" href="default_fr.aspx?lang=fr">Français</a>


                            </li>
                        </ul>
                    </div>
                </div>
            </section>
            <div class="row">
                <div class="brand col-xs-8 col-sm-9 col-md-6">
                    <a href="http://canada.ca/en/index.html"><object type="image/svg+xml" tabindex="-1" data="./distro/4.0.19/assets/sig-blk-en.svg"></object><span class="wb-inv"> Government of Canada</span></a>
                </div>

                <section class="wb-mb-links col-xs-4 col-sm-3 visible-sm visible-xs" id="wb-glb-mn">
                    <h2>Search and menus</h2>
                    <ul class="list-inline text-right chvrn">
                        <li><a href="#mb-pnl" title="Search and menus" aria-controls="mb-pnl" class="overlay-lnk" role="button"><span class="glyphicon glyphicon-search"><span class="glyphicon glyphicon-th-list"><span class="wb-inv">Search and menus</span></span></span></a></li>
                    </ul>
                    <div id="mb-pnl"></div>
                </section>
                <section id="wb-srch" class="col-xs-6 text-right visible-md visible-lg">
                    <h2 class="wb-inv">Search</h2>

                    <form action="http://recherche-search.gc.ca/rGs/s_r?#wb-land" method="get" name="cse-search-box" role="search" class="form-inline">
                        <div class="form-group">
                            <label for="wb-srch-q" class="wb-inv">Search website</label>
                            <input name="cdn" value="canada" type="hidden">
                            <input name="st" value="s" type="hidden">
                            <input name="num" value="10" type="hidden">
                            <input name="langs" value="eng" type="hidden">
                            <input name="st1rt" value="0" type="hidden">
                            <input name="s5bm3ts21rch" value="x" type="hidden">

                            <input id="wb-srch-q" list="wb-srch-q-ac" class="wb-srch-q form-control" name="q" type="search" value="" size="27" maxlength="150" placeholder="Search Canada.ca">
                            <datalist id="wb-srch-q-ac">
                                <!--[if lte IE 9]><select><![endif]-->
                                <!--[if lte IE 9]></select><![endif]-->
                            </datalist>
                        </div>
                        <div class="form-group submit">
                            <button type="submit" id="wb-srch-sub" class="btn btn-primary btn-small" name="wb-srch-sub"><span class="glyphicon-search glyphicon"></span><span class="wb-inv">Search</span></button>

                        </div>
                    </form>
                </section>
            </div>
        </div>
        <nav role="navigation" id="wb-sm" class="wb-menu visible-md visible-lg" data-trgt="mb-pnl" data-ajax-fetch="./distro/4.0.19/ajax/sitemenu-en.html" typeof="SiteNavigationElement">
            <h2 class="wb-inv">Topics menu</h2>
            <div class="container nvbar">
                <div class="row">
                    <ul class="list-inline menu">
                        <li><a href="http://www.esdc.gc.ca/en/jobs/index.page">Jobs</a></li>
                        <li><a href="http://www.cic.gc.ca/english/index.asp">Immigration</a></li>
                        <li><a href="http://travel.gc.ca/">Travel</a></li>
                        <li><a href="http://www.canada.ca/en/services/business/index.html">Business</a></li>
                        <li><a href="http://www.canada.ca/en/services/benefits/index.html">Benefits</a></li>
                        <li><a href="http://healthycanadians.gc.ca/index-eng.php">Health</a></li>
                        <li><a href="http://www.canada.ca/en/services/taxes/index.html">Taxes</a></li>
                        <li><a href="http://www.canada.ca/en/services/index.html">More services</a></li>
                    </ul>
                </div>
            </div>
        </nav>

    </header>
    <!-- HEADER END | FIN DE L'EN-TETE -->
    <!-- BREADCRUMB BEGINS | DEBUT DE BREADCRUMB -->
    <!--<tiles:insert attribute="breadCrumbs" /> -->
    <!-- BREADCRUMB ENDS | FIN DE BREADCRUMB -->
    <!-- CONTENT BEGINS | DEBUT DU CONTENU -->

        <main role="main" property="mainContentOfPage" class="container">
            <div id="body">
                <section class="featured">
                    <div class="content-wrapper">
                        <hgroup class="title">
                            <h1>Canada Vigilance Adverse Reaction Database - APIs</h1>
                        </hgroup>
                        <div class="col-md-4 col-sm-4">
                            <a href="http://localhost:64591/searchReport-en.html">Search by Brand Name</a>
                        </div>
                        
                        <div class="col-md-4 col-sm-4">
                                <a href="http://localhost:64591/reference-en.html">API Reference</a>
                        </div>
                            <table class="wb-tables table table-striped table-hover">
                                <thead>
                                    <tr>
                                        <th>
                                            Request by:
                                        </th>
                                        <th scope=colgroup colspan=2>
                                            Format:
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Drug product ingredients:</td>
                                        <td><a class="btn btn-default" href="/api/drugproductingredient/?type=json">Json</a></td>
                                        <td><a class="btn btn-default" href="/api/drugproductingredient/?type=xml">XML</a></td>
                                    </tr>
                                    <tr>
                                        <td>Drug Products:</td>
                                        <td> <a class="btn btn-default" href="/api/drugproduct/?type=json">Json</a></td>
                                        <td><a class="btn btn-default" href="/api/drugproduct/?type=xml">XML</a></td>
                                    </tr>
                                    <tr>
                                        <td>Gender:</td>
                                        <td> <a class="btn btn-default" href="/api/gender/?type=json">Json</a></td>
                                        <td><a class="btn btn-default" href="/api/gender/?type=xml">XML</a></td>
                                    </tr>
                                    <tr>
                                        <td>Outcome:</td>
                                        <td> <a class="btn btn-default" href="/api/outcome/?type=json">Json</a></td>
                                        <td><a class="btn btn-default" href="/api/outcome/?type=xml">XML</a></td>
                                    </tr>
                                    <tr>
                                        <td>Reactions:</td>
                                        <td> <a class="btn btn-default" href="/api/reaction/?type=json">Json</a></td>
                                        <td><a class="btn btn-default" href="/api/reaction/?type=xml">XML</a></td>
                                    </tr>
                                    <tr>
                                        <td>Report Drug:</td>
                                        <td> <a class="btn btn-default" href="/api/reportdrug/?type=json">Json</a></td>
                                        <td><a class="btn btn-default" href="/api/reportdrug/?type=xml">XML</a></td>
                                    </tr>
                                    <tr>
                                        <td>Report Drug Indication:</td>
                                        <td><a class="btn btn-default" href="/api/reportdrugindication/?type=json">Json</a></td>
                                        <td><a class="btn btn-default" href="/api/reportdrugindication/?type=xml">XML</a></td>
                                    </tr>
                                    <tr>
                                        <td>Report Links:</td>
                                        <td><a class="btn btn-default" href="/api/reportlink/?type=json">Json</a></td>
                                        <td><a class="btn btn-default" href="/api/reportlink/?type=xml">XML</a></td>
                                    </tr>
                                    <tr>
                                        <td>Report Type Lx:</td>
                                        <td><a class="btn btn-default" href="/api/reporttypelx/?type=json">Json</a></td>
                                        <td><a class="btn btn-default" href="/api/reporttypelx/?type=xml">XML</a></td>
                                    </tr>
                                    <tr>
                                        <td>Reports:</td>
                                        <td><a class="btn btn-default" href="/api/report/?type=json">Json</a></td>
                                        <td><a class="btn btn-default" href="/api/report/?type=xml">XML</a></td>
                                    </tr>
                                    <tr>
                                        <td>All Report by Drug Name:<input type="text" id="strDrugName" size="15" /></td>
                                        <td><a class="btn btn-default" href='' onclick="this.href='/api/report?drugname=' + '%' + document.getElementById('strDrugName').value + '%' + '&type=json'">Json</a></td>
                                        <td><a class="btn btn-default" href='' onclick="this.href = '/api/report?drugname=' + '%' + document.getElementById('strDrugName').value + '%' + '&type=xml'">XML</a></td>
                                    </tr>
                                    <tr>
                                        <td>Seriousness Lx:</td>
                                        <td><a class="btn btn-default" href="/api/seriousness/?type=json">Json</a></td>
                                        <td><a class="btn btn-default" href="/api/seriousness/?type=xml">XML</a></td>
                                    </tr>
                                    <tr>
                                        <td>Source Lx:</td>
                                        <td><a class="btn btn-default" href="/api/source/?type=json">Json</a></td>
                                        <td><a class="btn btn-default" href="/api/source/?type=xml">XML</a></td>
                                    </tr>
                                    <tr>
                                        <td>All Report Info:</td>
                                        <td><a class="btn btn-default" href="/api/reportinfo/?type=json">Json</a></td>
                                        <td><a class="btn btn-default" href="/api/reportinfo/?type=xml">XML</a></td>
                                    </tr>
                                    <tr>
                                        <td>All Report Info by Drug Name:<input type="text" id="strDrugName" size="15" /></td>
                                        <td><a class="btn btn-default" href='' onclick="this.href='/api/reportinfo?drugname=' + '%' + document.getElementById('strDrugName').value + '%' + '&type=json'">Json</a></td>
                                        <td><a class="btn btn-default" href='' onclick="this.href = '/api/reportinfo?drugname=' + '%' + document.getElementById('strDrugName').value + '%' + '&type=xml'">XML</a></td>
                                    </tr>
                                 
                                </tbody>
                            </table>

                        </div>
                </section>


            </div>

            <div class="row pagedetails">
                <div class="col-sm-5 col-xs-12 datemod">
                    <dl id="wb-dtmd">
                        <dt>Date modified:&#32;</dt>
                        <dd><time property="dateModified">2016-01-12</time></dd>
                    </dl>
                </div>
                <div class="clear visible-xs"></div>
                <div class="col-sm-4 col-xs-6">
                    <a href="http://www.canada.ca/en/contact/feedback.html" class="btn btn-default"><span class="glyphicon glyphicon-comment mrgn-rght-sm"></span>Feedback<span class="wb-inv"> about this web site</span></a>
                </div>
                <div class="col-sm-3 col-xs-6 text-right">
                    <div class="wb-share" data-wb-share='{"lnkClass": "btn btn-default"}'></div>
                </div>
                <div class="clear visible-xs"></div>
            </div>
        </main>
       <!-- CONTENT ENDS | FIN DU CONTENU -->
    <!-- FOOTER BEGINS | DEBUT DU PIED DE LA PAGE -->
    <footer role="contentinfo" id="wb-info">
        <nav role="navigation" class="container visible-sm visible-md visible-lg wb-navcurr">
            <h2 class="wb-inv">About this site</h2>
            <div class="row">
                <div class="col-sm-3 col-lg-3">
                    <section>
                        <h3>Contact information</h3>
                        <ul class="list-unstyled">
                            <li><a href="http://healthycanadians.gc.ca/report-signalez/index-eng.php">Report a concern</a></li>
                            <li><a href="http://healthycanadians.gc.ca/say-exprimez/index-eng.php">Public involvement</a></li>
                            <li><a href="http://healthycanadians.gc.ca/contact-contactez/index-eng.php">General enquiries</a></li>
                            <li><a href="http://healthycanadians.gc.ca/connect-connectez/index-eng.php">Stay connected</a></li>
                        </ul>
                    </section>
                    <section>
                        <h3>News</h3>
                        <ul class="list-unstyled">
                            <li><a href="http://news.gc.ca/web/index-en.do">Newsroom</a></li>
                            <li><a href="http://news.gc.ca/web/nwsprdct-en.do?mthd=tp&amp;crtr.tp1D=1">News releases</a></li>
                            <li><a href="http://news.gc.ca/web/nwsprdct-en.do?mthd=tp&amp;crtr.tp1D=3">Media advisories</a></li>
                            <li><a href="http://news.gc.ca/web/nwsprdct-en.do?mthd=tp&amp;crtr.tp1D=970">Speeches</a></li>
                            <li><a href="http://news.gc.ca/web/nwsprdct-en.do?mthd=tp&amp;crtr.tp1D=980">Statements</a></li>
                        </ul>
                    </section>
                </div>
                <section class="col-sm-3 col-lg-3">
                    <h3>Government</h3>
                    <ul class="list-unstyled">
                        <li><a href="http://www.canada.ca/en/gov/system/index.html">How government works</a></li>
                        <li><a href="http://www.canada.ca/en/gov/dept/index.html">Departments &amp; agencies</a></li>
                        <li><a href="http://pm.gc.ca/eng">Prime Minister</a></li>
                        <li><a href="http://www.canada.ca/en/gov/ministers/index.html">Ministers</a></li>
                        <li><a href="http://www.canada.ca/en/gov/policy/index.html">Policies, regulations &amp; laws</a></li>
                        <li><a href="http://www.canada.ca/en/gov/libraries/index.html">Libraries</a></li>
                        <li><a href="http://www.canada.ca/en/gov/publications/index.html">Publications</a></li>
                        <li><a href="http://www.canada.ca/en/gov/statistics/index.html">Statistics &amp; data</a></li>
                        <li><a href="http://www.canada.ca/en/newsite.html">About Canada.ca</a></li>
                    </ul>
                </section>
                <section class="col-sm-3 col-lg-3 brdr-lft">
                    <h3>Transparency</h3>
                    <ul class="list-unstyled">
                        <li><a href="http://www.canada.ca/en/transparency/reporting.html">Government-wide reporting</a></li>
                        <li><a href="http://www.canada.ca/en/transparency/open.html">Open government</a></li>
                        <li><a href="http://www.canada.ca/en/transparency/disclosure.html">Proactive disclosure</a></li>
                        <li><a href="http://www.canada.ca/en/transparency/terms.html">Terms &amp; conditions</a></li>
                        <li><a href="http://www.canada.ca/en/transparency/privacy.html">Privacy</a></li>
                    </ul>
                </section>
                <div class="col-sm-3 col-lg-3 brdr-lft">
                    <section>
                        <h3>Feedback</h3>
                        <p><a href="http://www.canada.ca/en/contact/feedback.html"><img src="./distro/4.0.19/assets/feedback.png" alt="Feedback about this Web site"></a></p>
                    </section>
                    <section>
                        <h3>Social media</h3>
                        <p><a href="http://www.canada.ca/en/social/index.html"><img src="./distro/4.0.19/assets/social.png" alt="Social media"></a></p>
                    </section>
                    <section>
                        <h3>Mobile centre</h3>
                        <p><a href="http://www.canada.ca/en/mobile/index.html"><img src="./distro/4.0.19/assets/mobile.png" alt="Mobile centre"></a></p>
                    </section>
                </div>
            </div>
        </nav>
        <div class="brand">
            <div class="container">
                <div class="row">
                    <div class="col-xs-6 visible-sm visible-xs tofpg">
                        <a href="#wb-cont">Top of Page <span class="glyphicon glyphicon-chevron-up"></span></a>
                    </div>
                    <div class="col-xs-6 col-md-12 text-right">
                        <object type="image/svg+xml" tabindex="-1" role="img" data="./distro/4.0.19/assets/wmms-blk.svg" aria-label="Symbol of the Government of Canada"></object>
                    </div>
                </div>
            </div>
        </div>
    </footer>

    <!-- FOOTER ENDS | FIN DU PIED DE LA PAGE -->
    <!--[if gte IE 9 | !IE ]><!-->
    <script src="./distro/4.0.19/js/jquery-2.1.1.min.js"></script>
    <script src="./distro/4.0.19/js/wet-boew.min.js"></script>
    <script src="./distro/4.0.19/js/theme.min.js"></script>
    <!--<![endif]-->
    <!--[if lt IE 9]>
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
        <script src="./distro/4.0.9/js/ie8-wet-boew.min.js"></script>
        <script src="./distro/4.0.9/js/ie8-wet-boew2.min.js"></script>
    <![endif]-->
</body>
</html>
