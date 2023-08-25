terraform init
terraform apply --auto-approve
az acr build --registry acrbernhackt --image webimage .
