#include <stdio.h>

typedef struct {
    char  id[50];
    float lat;
    float lon;
    float ratio;
} Water_Tower;

char filename_r[]="../list_water_tower.csv";
char filename_w[]="../water_tower_package/source/water_tower.xml";

char buffer[250];

float get_lat(char coord[]);
float get_lon(char coord[]);

int main() {
    Water_Tower water_tower;
    FILE * file_r =NULL;
    FILE * file_w = NULL;
    file_r = fopen (filename_r, "r");
    file_w = fopen (filename_w, "w");
    if (file_r == NULL) {
        printf("missing file or not well defined\n");
        return(1);
    }

    if (file_w ==NULL) {
        printf("error when file is created\n");
        return(1);
    }

    fprintf(file_w,"<?xml version=\"1.0\"?>\n<FSData version=\"9.0\">");

    int is_deg=0;
    char coord_lat[50];
    char coord_lon[50];
    int i=1;
    while (fgets(buffer,200,file_r)!=NULL) {  //200 char max per line
        water_tower.id[0]='\0';
        water_tower.lat=0.0;
        water_tower.lon=0.0;
        water_tower.ratio=1.0;
        int check_confo=1;
        int k=0,check_item=0;
        while(buffer[k]!='\0'){
            if (check_item && (buffer[k]>'A') && (buffer[k]<'Z')) {
	            is_deg=1;		
	        }
            if (buffer[k]==';') {
                check_confo=0;
                check_item=1;
            }

            if (buffer[k]==',') {
                buffer[k]='.';
            }
            k++;
        }
        if (check_confo) {
            printf("syntax error, check the .csv file\n");
            continue;
        }
        if (is_deg) {
            if (sscanf(buffer,"%[^;];%[^;];%[^;];%f",water_tower.id,coord_lat,coord_lon,&(water_tower.ratio))!=4) {
                printf("water_tower %i is not complete\n",i);
            };
            water_tower.lat=get_lat(coord_lat);
            water_tower.lon=get_lon(coord_lon);
        }
        else {
            if (sscanf(buffer,"%[^;];%f;%f;%f",water_tower.id,&(water_tower.lat),&(water_tower.lon),&(water_tower.ratio))!=4) {
                printf("water_tower %i is not complete\n",i);
            };	    
        }

        fprintf(file_w,"\n\t<!--SceneryObject name: Water_Tower_FR-->\n\t<SceneryObject lat=\"%f\" lon=\"%f\" alt=\"0.00000000000000\" pitch=\"0.000068\" bank=\"-0.000068\" heading=\"-179.999991\" imageComplexity=\"VERY_SPARSE\" altitudeIsAgl=\"TRUE\" snapToGround=\"TRUE\" snapToNormal=\"FALSE\">\n\t\t<LibraryObject name=\"{93EE3F27-3429-4CC7-A9CC-0FB5ED33AFC2}\" scale=\"%f\"/>\n\t</SceneryObject>",water_tower.lat,water_tower.lon,water_tower.ratio);    
     //   printf("loop %i ends, is_deg: %i\n",i,is_deg);
        i++;
    }

    fprintf(file_w,"\n</FSData>");
    fclose(file_r);
    fclose(file_w); 

    printf("import done ! Just wait a few seconds that the compilation process starts...\n");
    return 0;
    
}

float get_lat(char coord[]) {
    float a,b,c;
    char d;
    sscanf(coord,"%f%*[^0-9]%f%*[^0-9]%f%*[^A-Z]%c",&a,&b,&c,&d);
    //printf("%f %f %f %c\n",a,b,c,d);
    float res=(a+b/60+c/3600);
    if (d=='N') {
        return (a+b/60+c/3600);
    }
    else {
        return -(a+b/60+c/3600);
    }   
}

float get_lon(char coord[]) {
    float a,b,c;
    char d;
    sscanf(coord,"%f%*[^0-9]%f%*[^0-9]%f%*[^A-Z]%c",&a,&b,&c,&d);
  //  printf("%i %i %i %c\n",a,b,c,d);
    if (d=='E') {
        return (a+b/60+c/3600);
    }
    else {
        return -(a+b/60+c/3600);
    }   
}

  
