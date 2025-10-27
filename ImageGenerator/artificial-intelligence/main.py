import sys
import json
from diffusers import DiffusionPipeline
import torch

# Check CUDA availability
# print("PyTorch CUDA build:", torch.version.cuda)
# print("CUDA available:", torch.cuda.is_available())
# print("Number of GPUs:", torch.cuda.device_count())

pipe = DiffusionPipeline.from_pretrained("CompVis/stable-diffusion-v1-4")
pipe.to("cuda")

def generate_image(prompt):
    image = pipe(prompt).images[0]
    fileName = "output.png"
    image.save(fileName)
    return fileName

def generate_image_multiple(prompt):
    result = pipe(
        prompt, 
        num_images_per_prompt=4
    )
    files = []
    for i, img in enumerate(result.images):
        fileName = f"output{i+1}.png"
        img.save(fileName)
        files.append(fileName)
    return files

def generate_image_high_detail(prompt, imageCount = 1):
    result = pipe(
        prompt,
        num_inference_steps=75,
        guidance_scale=9,
        height=1024,
        width=1024,
        num_images_per_prompt=imageCount
    )
    files = []
    for i, img in enumerate(result.images):
        fileName = f"output{i+1}.png"
        img.save(fileName)
        files.append(fileName)
    return files

def echo(text):
    return f"echo: {text}"


for line in sys.stdin:
    try:
        data = json.loads(line)
        func = data.get("function")
        parameter1 = data.get("parameter1")
        parameter2 = data.get("parameter2")
        # parArr = data.get("parArr", [])
        # parObj = data.get("parObj", {})

        if (func == "generate_image" and parameter2 == "4"):
            func = "generate_image_multiple"  

        if func == "generate_image":
            result = generate_image(parameter1)
        elif func == "generate_image_multiple":
            result = generate_image_multiple(parameter1)    
        elif func == "generate_image_high_detail":
            result = generate_image_high_detail(parameter1, int(parameter2))    
        elif func == "echo":
            result = echo(parameter1)
        else:
            result = f"Unknown function: {func}"

        print(json.dumps({"result": result}))
        sys.stdout.flush()
    except Exception as e:
        print(json.dumps({"error": str(e)}))
        sys.stdout.flush()
