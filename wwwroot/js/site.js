function watchChanges(formId) {
    const form = document.getElementById(formId);

    const inputFields = form.querySelectorAll("input");
    const textAreas = form.querySelectorAll("textarea");

    /**@type {HTMLButtonElement}*/
    const submitButton = form.querySelector('button[type="submit"]');

    const fields = [...inputFields, ...textAreas]

    const oldObject = {}
    const newObject = {}

    for (const e of fields) {
        oldObject[e.name] = e.value
        newObject[e.name] = e.value
    }


    function validate() {
        let changes = false;
        for (const key in oldObject) {
            if (oldObject[key] != newObject[key]) {
                changes = true;
                break;
            }
        }
        submitButton.disabled = !changes
    }

    function changeHandler(event) {
        const e = event.target;
        newObject[e.name] = e.value
        validate()
    }

    for (const e of fields) e.addEventListener("input", changeHandler)
   
}

