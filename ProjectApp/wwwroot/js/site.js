

    document.addEventListener('DOMContentLoaded', function () {
        let sw = document.querySelector('#switch-mode')

        sw.addEventListener('change', function () {
            let theme = this.checked ? "dark" : "light";
            document.body.className = theme;

            fetch(`/sitesettingscontroller/changetheme?theme=${theme}`)
                .then(res => {
                    if (res.ok)
                        window.location.reload()
                    else
                        console.log("something")
                })
        })
    })


