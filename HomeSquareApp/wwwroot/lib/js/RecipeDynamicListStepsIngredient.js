
function textAreaAdjust(element) {
    element.style.height = "1px";
    element.style.height = (25 + element.scrollHeight) + "px";
}

$(document).on("keydown", ":input:not(textarea)", function (event) {
    return event.key != "Enter";
});

/*recipeImage.style.backgroundImage = "url('/lib/images/products/productPlaceholder.png')";*/

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            //console.log(e.target.result)
            recipeImage.style.backgroundImage = "url('" + e.target.result + "')";;
        }

        const file = input.files[0];

        const fileType = file['type'];

        const validImageTypes = ['image/gif', 'image/jpeg', 'image/jpg', 'image/png'];
        if (validImageTypes.includes(fileType)) {
            reader.readAsDataURL(file);
        }
    }
}


$("#Image").change(function () {
    readURL(this);
});

$("#addIngredient").click(function () {
    var rowHtml = `<div class="ingredientContentWrapper d-flex my-3" id="IngredientContent` + nextIngredientId + `">

                            <div class="form-floating col-4">
                                <input name="Ingredients[`+ nextIngredientId + `].ServingContent" type="text" class="ingredientServingContent form-control" placeholder="0">
                                <label>Amount</label>
                            </div>
                            <div class="form-floating flex-fill">
                                <input  name="Ingredients[`+ nextIngredientId + `].IngredientName" type="text" class="ingredientName form-control" onkeyup="app.triggerSearchQuery(this)">
                                <label>Ingredient Name</label>
                            </div>
                            <button type="button" onclick="removeIngredient('IngredientContent'+`+ nextIngredientId + `)" class="ingredientContentRemove text-danger fw-bold btn btn-default">X</button>
                        </div>`
    nextIngredientId++;

    $("#ingredientRow").append(rowHtml);
});

function removeIngredient(elementID) {
    var el = document.getElementById(elementID)
    el.remove();
    nextIngredientId--;

    var ingredientContentWrapper = document.getElementsByClassName("ingredientContentWrapper")
    var ingredientContentRemove = document.getElementsByClassName("ingredientContentRemove")
    var ingredientServingContent = document.getElementsByClassName("ingredientServingContent")
    var ingredientName = document.getElementsByClassName("ingredientName")
    for (i = 0; i < nextIngredientId; i++) {
        ingredientContentWrapper[i].id = "IngredientContent" + i
        ingredientContentRemove[i].setAttribute("onClick", "removeIngredient('IngredientContent" + i + "');");
        ingredientServingContent[i].setAttribute("name", "Ingredients[" + i + "].ServingContent")
        ingredientName[i].setAttribute("name", "Ingredients[" + i + "].IngredientName")
    }
}




$("#addInstruction").click(function () {

    var rowHtml = `<div class="instructionStepWrapper card shadow-sm pt-5 pb-4 px-4 my-2" id="StepsContent` + nextInstructionId + `">
                            <div class="position-absolute start-0 top-0 mx-4 mt-3">
                                <small class="fw-bold">Step <span class="step-number">`+ (nextInstructionId + 1) + `</span></small>
                                <a style="cursor:pointer" onclick="removeSteps('StepsContent`+ nextInstructionId + `')" class="instructionStepRemove text-decoration-none text-danger fw-bold">X</a>
                            </div>
                            <div>
                                <div class="form-floating">
                                    <textarea id="RecipeSteps_`+ nextInstructionId + `__Steps" name="RecipeSteps[` + nextInstructionId + `].Steps" class="stepTextArea form-control" onkeyup="textAreaAdjust(this)" style="height: 85px" placeholder="Describe Instruction"></textarea>
                                    <label for="RecipeSteps_`+ nextInstructionId + `__Steps">Instruction</label>
                                </div>
                            </div>
                        </div>`

    nextInstructionId++;

    $("#stepsRow").append(rowHtml);
});

function removeSteps(elementID) {
    var el = document.getElementById(elementID)
    el.remove();
    nextInstructionId--;

    var instructionStepWrapper = document.getElementsByClassName("instructionStepWrapper")
    var instructionStepRemove = document.getElementsByClassName("instructionStepRemove")
    var stepNumbers = document.getElementsByClassName("step-number")
    var stepTextArea = document.getElementsByClassName("stepTextArea")
    var stepTextAreaLabel = document.getElementById("stepTextAreaLabel")
   
    for (i = 0; i < nextInstructionId; i++) {
        instructionStepWrapper[i].id = "StepsContent" + i
        instructionStepRemove[i].setAttribute("onClick", "removeSteps('StepsContent" + i + "');");
        stepNumbers[i].innerHTML = (i + 1);
        stepTextArea[i].id = "RecipeSteps_" + i + "__Steps"
        stepTextArea[i].setAttribute("name", "RecipeSteps[" + i + "].Steps")
        
    }
}
