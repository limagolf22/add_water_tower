#include <stdio.h>

typedef struct {
    int id;
    char  name[50];
    float lat;
    float lon;
    float height;
} Object;

char * object_names[]={"Water_Tower_FR"};
char * object_ids[]={"93EE3F27-3429-4CC7-A9CC-0FB5ED33AFC2"};
float object_heights[]={15.0};

//char filename_r[];
char filename_w[]="../water_tower_package/source/water_tower.xml";

char buffer[250];

float get_lat(char coord[]);
float get_lon(char coord[]);

int main(int argc, char *argv[]) {
    Object object;

    FILE * file_w = NULL;
    if (argc<=1) {
        printf("at least 1 .csv file is necessary");
        return(1);
    }
    file_w = fopen (filename_w, "w");
    if (file_w ==NULL) {
        printf("error when file is created\n");
        return(1);
    }
    fprintf(file_w,"<?xml version=\"1.0\"?>\n<FSData version=\"9.0\">");

    int ai;
    for (ai=1;ai<argc;ai++) {
        
        FILE * file_r =NULL;
       
        file_r = fopen(argv[ai], "r");
        if (file_r == NULL) {
            printf("missing file : %s  or not well defined\n",argv[ai]);
            return(1);
        }
        printf("ouverture fichier %s\n",argv[ai]);

        int is_deg=0;
        char coord_lat[50];
        char coord_lon[50];
        int i=1;
        
        while (fgets(buffer,200,file_r)!=NULL) {  //200 char max per line
            object.id=0;
            object.name[0]='\0';
            object.lat=0.0;
            object.lon=0.0;
            object.height=1.0;
            int check_confo=1;
            int k=0,check_item=0;

            while(buffer[k]!='\0'){
                if ((check_item>=2) && (buffer[k]>'A') && (buffer[k]<'Z')) {
                    is_deg=1;		
                }
                if (buffer[k]==';') {
                    check_confo=0;
                    check_item++;
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
                if (sscanf(buffer,"%d;%[^;];%[^;];%[^;];%f",object.id,object.name,coord_lat,coord_lon,&(object.height))!=5) {
                    printf("object %d is not complete\n",i);
                };
                object.lat=get_lat(coord_lat);
                object.lon=get_lon(coord_lon);
            }
            else {
                if (sscanf(buffer,"%d;%[^;];%f;%f;%f",&(object.id),object.name,&(object.lat),&(object.lon),&(object.height))!=5) {
                    printf("object %i is not complete\n",i);
                };	    
            }

        fprintf(file_w,"\n\t<!--SceneryObject name: %s-->\n\t<SceneryObject lat=\"%f\" lon=\"%f\" alt=\"0.00000000000000\" pitch=\"0.000000\" bank=\"0.000000\" heading=\"-180.00\" imageComplexity=\"VERY_SPARSE\" altitudeIsAgl=\"TRUE\" snapToGround=\"TRUE\" snapToNormal=\"FALSE\">\n\t\t<LibraryObject name=\"{%s}\" scale=\"%f\"/>\n\t</SceneryObject>",object_names[object.id],object.lat,object.lon,object_ids[object.id],object.height/object_heights[object.id]);    
         // printf("loop %i ends, is_deg: %i\n",i,is_deg);
            i++;
        }

        fclose(file_r);
    }
    
    fprintf(file_w,"\n</FSData>");
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

