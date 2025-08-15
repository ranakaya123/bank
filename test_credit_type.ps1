# Test Credit Type API
$body = @{
    "Name" = "Test Kredi"
    "Description" = "Test Açıklama"
    "MinAmount" = 1000
    "MaxAmount" = 5000
    "MinTerm" = 6
    "MaxTerm" = 24
    "InterestRate" = 15
    "Category" = 0
} | ConvertTo-Json

Write-Host "Request Body:"
Write-Host $body

try {
    $response = Invoke-WebRequest -Uri 'https://localhost:7041/api/CreditTypes' -Method POST -Body $body -ContentType 'application/json'
    Write-Host "Response Status: $($response.StatusCode)"
    Write-Host "Response Body: $($response.Content)"
} catch {
    Write-Host "Error: $($_.Exception.Message)"
    if ($_.Exception.Response) {
        Write-Host "Status Code: $($_.Exception.Response.StatusCode)"
        Write-Host "Response Content: $($_.Exception.Response.Content)"
    }
}
