# Set-up
find . -type d -name ".generated" | xargs rm -rf
find . -type d -name "Adapters.Rest.Generated" | xargs rm -rf
mkdir Adapters.Rest.Generated

docker run --rm --user "$(id -u):$(id -g)" -v "${PWD}:/local" openapitools/openapi-generator-cli generate \
    -i https://raw.githubusercontent.com/arjen1981/zeebe-demo-livingdocumentation/main/docs/openapi.yaml \
    -g aspnetcore \
    -o /local/.generated \
    --additional-properties=aspnetCoreVersion=5.0,buildTarget=library,operationIsAsync=true,operationResultTask=true,packageName=Adapters.Rest.Generated,swashbuckleVersion=5.0.0

# Copy generated .cs files
cd .generated/src/Adapters.Rest.Generated
find -type f -name '*.cs' | 
    while read FILE; do cp --parents "$FILE" ../../../Adapters.Rest.Generated; done

# # Clean up
cd ../../..
rm -rf .generated