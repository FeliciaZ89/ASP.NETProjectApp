


document.addEventListener('DOMContentLoaded', function () {
    handleProfileImageUpload();
})

function handleProfileImageUpload() {
    try {
        let fileUploder = document.querySelector('#fileUploader')

        if (fileUploder != undefined) {
            fileUploder.addEventListener('change', function () {
                if (this.files.length > 0) {
                    this.form.submit()
                }
            })
        }
    }
    catch { }
}
