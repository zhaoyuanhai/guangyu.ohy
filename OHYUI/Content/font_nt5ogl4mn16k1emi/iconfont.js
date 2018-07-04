;(function(window) {

  var svgSprite = '<svg>' +
    '' +
    '<symbol id="icon-down" viewBox="0 0 1024 1024">' +
    '' +
    '<path d="M783.451937 322.173454 512.001583 593.15047 240.552812 322.173454c-20.036899-20.021068-52.485056-20.021068-72.521955 0-10.011326 10.011326-15.026487 23.114384-15.026487 36.226942 0 13.11414 5.015161 26.226697 15.026487 36.233274l307.707373 307.199208c10.016075 10.011326 23.134964 15.010656 36.263352 15.010656 13.118889 0 26.242528-5.000914 36.258603-15.010656l307.713706-307.200792c10.004993-10.004993 15.021738-23.119134 15.021738-36.233274s-5.015161-26.217199-15.021738-36.226942C835.93066 302.150803 803.484087 302.150803 783.451937 322.173454z"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '<symbol id="icon-type" viewBox="0 0 1040 1024">' +
    '' +
    '<path d="M0 150.588235l0 331.294118 481.882353 0L481.882353 0 150.588235 0C67.418353 0 0 67.433412 0 150.588235zM316.235294 60.235294c66.529882 0 105.411765-0.647529 105.411765 0l0 361.411765c0 0.180706-38.881882 0-105.411765 0L165.647059 421.647059c-66.529882 0-105.411765 0.180706-105.411765 0L60.235294 180.705882c0-66.529882 53.940706-120.470588 120.470588-120.470588L316.235294 60.235294zM888.470588 0 557.176471 0l0 481.882353 481.882353 0L1039.058824 150.588235C1039.058824 67.433412 971.625412 0 888.470588 0zM978.823529 421.647059c0 0.180706-38.881882 0-105.411765 0L722.823529 421.647059c-66.529882 0-105.411765 0.180706-105.411765 0L617.411765 60.235294c0-0.647529 38.881882 0 105.411765 0l135.529412 0c66.544941 0 120.470588 53.940706 120.470588 120.470588L978.823529 421.647059zM0 873.411765C0 956.581647 67.418353 1024 150.588235 1024l331.294118 0L481.882353 542.117647 0 542.117647 0 873.411765zM60.235294 602.352941c0-0.180706 38.881882 0 105.411765 0l150.588235 0c66.529882 0 105.411765-0.180706 105.411765 0l0 361.411765c0 0.662588-38.881882 0-105.411765 0l-135.529412 0c-66.529882 0-120.470588-53.925647-120.470588-120.470588L60.235294 602.352941zM557.176471 1024l331.294118 0c83.154824 0 150.588235-67.418353 150.588235-150.573176L1039.058824 542.117647 557.176471 542.117647 557.176471 1024zM617.411765 602.352941c0-0.180706 38.881882 0 105.411765 0l150.588235 0c66.529882 0 105.411765-0.180706 105.411765 0l0 240.941176c0 66.544941-53.925647 120.470588-120.470588 120.470588l-135.529412 0c-66.529882 0-105.411765 0.662588-105.411765 0L617.411765 602.352941z"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '</svg>'
  var script = function() {
    var scripts = document.getElementsByTagName('script')
    return scripts[scripts.length - 1]
  }()
  var shouldInjectCss = script.getAttribute("data-injectcss")

  /**
   * document ready
   */
  var ready = function(fn) {
    if (document.addEventListener) {
      if (~["complete", "loaded", "interactive"].indexOf(document.readyState)) {
        setTimeout(fn, 0)
      } else {
        var loadFn = function() {
          document.removeEventListener("DOMContentLoaded", loadFn, false)
          fn()
        }
        document.addEventListener("DOMContentLoaded", loadFn, false)
      }
    } else if (document.attachEvent) {
      IEContentLoaded(window, fn)
    }

    function IEContentLoaded(w, fn) {
      var d = w.document,
        done = false,
        // only fire once
        init = function() {
          if (!done) {
            done = true
            fn()
          }
        }
        // polling for no errors
      var polling = function() {
        try {
          // throws errors until after ondocumentready
          d.documentElement.doScroll('left')
        } catch (e) {
          setTimeout(polling, 50)
          return
        }
        // no errors, fire

        init()
      };

      polling()
        // trying to always fire before onload
      d.onreadystatechange = function() {
        if (d.readyState == 'complete') {
          d.onreadystatechange = null
          init()
        }
      }
    }
  }

  /**
   * Insert el before target
   *
   * @param {Element} el
   * @param {Element} target
   */

  var before = function(el, target) {
    target.parentNode.insertBefore(el, target)
  }

  /**
   * Prepend el to target
   *
   * @param {Element} el
   * @param {Element} target
   */

  var prepend = function(el, target) {
    if (target.firstChild) {
      before(el, target.firstChild)
    } else {
      target.appendChild(el)
    }
  }

  function appendSvg() {
    var div, svg

    div = document.createElement('div')
    div.innerHTML = svgSprite
    svgSprite = null
    svg = div.getElementsByTagName('svg')[0]
    if (svg) {
      svg.setAttribute('aria-hidden', 'true')
      svg.style.position = 'absolute'
      svg.style.width = 0
      svg.style.height = 0
      svg.style.overflow = 'hidden'
      prepend(svg, document.body)
    }
  }

  if (shouldInjectCss && !window.__iconfont__svg__cssinject__) {
    window.__iconfont__svg__cssinject__ = true
    try {
      document.write("<style>.svgfont {display: inline-block;width: 1em;height: 1em;fill: currentColor;vertical-align: -0.1em;font-size:16px;}</style>");
    } catch (e) {
      console && console.log(e)
    }
  }

  ready(appendSvg)


})(window)